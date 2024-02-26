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
        public static Dictionary<string, string> connections = new Dictionary<string, string>(); // Connects key (OthelloMenu Program.ID) with value (SignalR ConnectionID)

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

        public void JoinRoom(int roomID, string password, string ID)
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
                    string wc = OthelloDB.QueryStrScalar($"SELECT WhiteConnection FROM Game_Basic WHERE GameID = {roomID}");
                    
                    if (bc == wc)
                    {
                        throw new Exception("Help");
                    }
                    else if (bc == null)
                    {
                        if (wc == null)
                        {
                            OthelloDB.QueryNoResult($"UPDATE Game_Basic SET BlackConnection = '{ID}' WHERE GameID = 1");
                            player = 'B';
                            opponentConnected = false;
                        }
                        else
                        {
                            throw new Exception("Help");
                        }
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
                    else
                    {
                        throw new Exception("Help");
                    }
                }

                Clients.Caller.ReturnGameInfo(opponentConnected, player);
            }
        }

        public void MakeMove(string move)
        {
            // ------------------------------------------------------------------------------------------------------------------------------------------------------ TODO
        }

        public void Hello(string ID)
        {
            if (Guid.TryParse(ID, out _))
            {
                connections[ID] = Context.ConnectionId;
            }
        }

        public void Leaving(string ID)
        {
            if (Guid.TryParse(ID, out _)) 
            {
                OthelloDB.QueryNoResult($"DELETE FROM Connection_Basic WHERE ConnectionID = '{ID}'"); // I know this could be insecure DEFINITELY ID - fix
                Console.WriteLine($"{ID} is leaving");
            }
        }

        public override Task OnConnected()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine($"Client disconnected: {Context.ConnectionId}");
            return base.OnDisconnected(stopCalled);
        }
    }
}