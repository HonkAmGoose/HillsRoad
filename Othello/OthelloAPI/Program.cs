using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;

namespace Othello
{
    /// <summary>
    /// Server program which deals with SignalR connections to clients and database calls
    /// </summary>
    public class Program
    {
        private const string Url = "http://localhost:9082";

        /// <summary>
        /// Main method to clean up database and start the server
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Console.WriteLine("Server started");

            DeleteOldRoomsAndConns();

            StartServer();
        }

        // Testing main
        /*
        private static void Main(string[] args)
        {
            MyHub.GetOpponentID("7e309c85-e20d-476a-a30f-d4ffe7bb9fe8", 'B');
        }
        */

        /// <summary>
        /// Starts the server using SignalR
        /// </summary>
        private static void StartServer()
        {
            using (WebApp.Start(Url, Configuration))
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();

                Console.WriteLine($"Server running on {Url}");

                while (true) ;
            }
        }

        /// <summary>
        /// Deletes rooms older than 2 days
        /// </summary>
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

        /// <summary>
        /// Configures SignalR
        /// </summary>
        /// <param name="app"></param>
        public static void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}