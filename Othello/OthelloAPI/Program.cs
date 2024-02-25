using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;

namespace Othello // THIS IS ACTUALLY THE SERVER
{
    public class Program
    {
        private const string Url = "http://localhost:9082";

        public List<string> messages = new List<string>();

        private static void Main(string[] args)
        {
            Console.WriteLine("Server started");

            // Housekeeping
            DeleteOldRoomsAndConns();

            // Start server
            using (WebApp.Start(Url, Configuration))
            {
                string message;
                bool dc = false;
                var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();

                Console.WriteLine($"Server running on {Url}");

                do
                {
                    message = Console.ReadLine();
                    if (message.ToLower() == "q")
                    {
                        dc = true;
                        message = "--- SERVER SHUTTING DOWN ---";
                    }

                    // Send message to all connected clients
                    context.Clients.All.addMessage("Server", message);
                } while (dc == false);

                Console.ReadLine();
            }
        }

        private static void DeleteOldRoomsAndConns()
        {
            int date = DateTime.Now.DayOfYear;
            string query = "DELETE FROM Room WHERE DateCreated <= " + (date - 2).ToString();
            if (date <= 2)
            {
                query += "OR DateCreated >= " + (date + 363).ToString();
            }
            OthelloDB.QueryNoResult(query);

            OthelloDB.QueryNoResult("DELETE FROM Connection_Basic WHERE RoomID < (SELECT TOP 1 RoomID FROM Room)");
        }

        public static void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}