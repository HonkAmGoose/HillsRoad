using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using System.IO;
using System.Linq;
using System.Security.Principal;

namespace Othello
{
    public class MyHub : Hub
    {
        /// <summary>
        /// Connects key (OthelloMenu Program.ID) with value (SignalR ConnectionID)
        /// </summary>
        public static Dictionary<string, string> connectionsDict = new Dictionary<string, string>();

        /// <summary>
        /// Allows a client wants to create a new room, "returns" roomID and password
        /// </summary>
        public void CreateRoom()
        {
            Console.WriteLine("debug start CreateRoom");
            
            string[] words = File.ReadAllLines("C:\\Users\\Dom\\My stuff\\SixthForm\\Computer Science\\Code\\Othello\\OthelloClient\\Words.txt");
            Random random = new Random();
            string password = words[random.Next(words.Length)];
            
            int roomID = OthelloDB.QueryIntScalar
                (
                    $"INSERT INTO Room(Password, DateCreated) VALUES ('{password}', '{DateTime.Now.DayOfYear}'); " + // I know this could be insecure - fix
                    "SELECT TOP 1 RoomID FROM Room ORDER BY RoomID DESC;"
                );
            
            Console.WriteLine($"debug CreateRoom returning {roomID} {password}");
            Clients.Caller.ReturnRoom(roomID, password);
        }

        /// <summary>
        /// Allows a client to join an existing room, "returns" whether or not it was successful
        /// </summary>
        /// <param name="roomID">ID of the room to join</param>
        /// <param name="password">password of the room to join</param>
        /// <param name="ID">ID of the client</param>
        public void JoinRoom(string ID, int roomID, string password)
        {
            if (
                password.Length == 5
                && password.All(char.IsLetter)
                && Guid.TryParse(ID, out _)
                && OthelloDB.QueryIntScalar($"SELECT COUNT(*) FROM Room WHERE RoomID = {roomID} AND [Password] = '{password}'") == 1
                && OthelloDB.QueryIntScalar($"SELECT COUNT(*) FROM Connection_Basic WHERE RoomID = {roomID}") < 2
                )
            {
                OthelloDB.QueryNoResult($"INSERT INTO Connection_Basic(RoomID, ConnectionID) VALUES ({roomID}, '{ID}')"); // I know this could be insecure MAINLY ID - fix
                Clients.Caller.ReturnJoined();
            }
            else
            {
                Clients.Caller.ReturnDenied();
            }

        }

        /// <summary>
        /// Gets information about the currently playing game for a client
        /// </summary>
        /// <param name="ID">ID of the client</param>
        /// <exception cref="Exception">Should not be thrown in theory if the db stays ok</exception>
        public void GetGameInfo(string ID)
        {
            if (Guid.TryParse(ID, out _))
            {
                int roomID = OthelloDB.QueryIntScalar($"SELECT RoomID FROM Connection_Basic WHERE ConnectionID = '{ID}'"); // I know this could be insecure DEFINITELY ID - fix
                int gameID = OthelloDB.QueryIntScalar($"SELECT CurrentGame FROM Room WHERE RoomID = {roomID}");
                bool opponentConnected;
                char player;

                if (gameID == -1) // Create new game
                {
                    gameID = OthelloDB.QueryIntScalar
                        (
                            $"INSERT INTO Game_Basic(NumberOfTurns, BlackConnection) VALUES (0, '{ID}'); " +
                            $"SELECT TOP 1 GameID FROM Game_Basic ORDER BY GameID DESC;"
                        );
                    OthelloDB.QueryNoResult($"UPDATE Room SET CurrentGame = {gameID} WHERE RoomID = {roomID}");
                    player = 'B';
                    opponentConnected = false;
                }
                else
                {
                    string bc = OthelloDB.QueryStrScalar($"SELECT BlackConnection FROM Game_Basic WHERE GameID = {gameID}");
                    string wc = OthelloDB.QueryStrScalar($"SELECT WhiteConnection FROM Game_Basic WHERE GameID = {gameID}");
                    
                    if (bc == wc)
                    {
                        throw new Exception("Help");
                    }
                    else if (bc == ID)
                    {
                        player = 'B';
                        opponentConnected = wc != null;
                    }
                    else if (wc == ID)
                    {
                        player = 'W';
                        opponentConnected = bc != null;
                    }
                    else if (bc == null)
                    {
                        OthelloDB.QueryNoResult($"UPDATE Game_Basic SET BlackConnection = '{ID}' WHERE GameID = {gameID}");
                        player = 'B';
                        opponentConnected = false;
                    }
                    else if (wc == null)
                    {
                        OthelloDB.QueryNoResult($"UPDATE Game_Basic SET WhiteConnection = '{ID}' WHERE GameID = {gameID}");
                        player = 'W';
                        opponentConnected = false;
                    }
                    else
                    {
                        throw new Exception("Help");
                    }
                }

                Clients.Caller.ReturnGameInfo(opponentConnected, player);
            }
        }

        /// <summary>
        /// Allows a client to send a move to the opponent
        /// </summary>
        /// <param name="ID">ID of the client</param>
        /// <param name="player">'B' or 'W' representing which player the client is</param>
        /// <param name="move">The move to send</param>
        public void MakeMove(string ID, char player, string move)
        {
            if (Guid.TryParse(ID, out _))
            {
                Clients.Client(connectionsDict[GetOpponentID(ID, player)]).OpponentMove(move);
            }
        }

        /// <summary>
        /// Used to make sure that the connectionsDict is up-to-date
        /// </summary>
        /// <param name="ID">ID of the client</param>
        public void Hello(string ID)
        {
            if (Guid.TryParse(ID, out _))
            {
                connectionsDict[ID] = Context.ConnectionId;
            }
        }

        /// <summary>
        /// Allows a client to exit gracefully
        /// </summary>
        /// <param name="ID">ID of the client</param>
        public void Leaving(string ID)
        {
            if (Guid.TryParse(ID, out _)) 
            {
                OthelloDB.QueryNoResult($"DELETE FROM Connection_Basic WHERE ConnectionID = '{ID}'"); // I know this could be insecure DEFINITELY ID - fix
                Console.WriteLine($"{ID} is leaving");
            }
        }

        /// <summary>
        /// Used in above methods to get an opponent's ID
        /// </summary>
        /// <param name="ID">Client ID</param>
        /// <param name="player">'B' or 'W' representing which player the client is</param>
        /// <returns>Opponent's client ID</returns>
        /// <exception cref="ArgumentException">If player isn't valid</exception>
        public static string GetOpponentID(string ID, char player)
        {
            int roomID = OthelloDB.QueryIntScalar($"SELECT RoomID FROM Connection_Basic WHERE ConnectionID = '{ID}'"); // I know this could be insecure DEFINITELY ID - fix
            int gameID = OthelloDB.QueryIntScalar($"SELECT CurrentGame FROM Room WHERE RoomID = {roomID}");

            return OthelloDB.QueryStrScalar($"SELECT {((player == 'B') ? "White" : (player == 'W') ? "Black" : throw new ArgumentException("Player should be 'B' or 'W'"))}Connection FROM Game_Basic WHERE GameID = {gameID}");
        }
    }
}