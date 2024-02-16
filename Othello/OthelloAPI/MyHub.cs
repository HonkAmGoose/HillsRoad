using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using System.IO;

namespace Othello
{
    public class MyHub : Hub
    {
        public static List<string> messages = new List<string>();
 
        public string addMessage(string name, string message)
        {
            Console.WriteLine($"Server receive: {name} - {message}");
            
            Clients.All.addMessage(name, message);

            messages.Add(message);

            return message;
        }

        public void createRoom()
        {
            Console.WriteLine("Start");
            string[] words = File.ReadAllLines("C:\\Users\\Dom\\My stuff\\SixthForm\\Computer Science\\Code\\Othello\\OthelloClient\\Words.txt");
            Random random = new Random();
            string password = words[random.Next(words.Length)];
            int roomID;
            using (var database = new SqlConnection(Program.connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    $"INSERT INTO Room(Password) VALUES ('{password}'); " + // I know this could be insecure - fix
                    "SELECT TOP 1 RoomID FROM Room ORDER BY RoomID DESC;",
                    database);
                database.Open();

                roomID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            Console.WriteLine($"Returning {roomID} {password}");
            Clients.User(Context.User.Identity.Name).returnRoom(roomID, password);
            // (roomID, password);
        }


        public void selectAll(string test)
        {
            return;
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