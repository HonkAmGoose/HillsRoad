using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;

namespace Othello // THIS IS ACTUALLY THE SERVER
{
    /// <summary>
    /// Server program which deals with SignalR connections to clients and database calls
    /// </summary>
    public class Program
    {
        private const string Url = "http://localhost:9082";

        public List<string> messages = new List<string>();

        
        private static void Main(string[] args)
        {
            Console.WriteLine("Server started");

            DeleteOldRoomsAndConns();

            StartServer();
        }
        

        /*
        private static void Main(string[] args)
        {
            MyHub.GetOpponentID("7e309c85-e20d-476a-a30f-d4ffe7bb9fe8", 'B');
        }
        */

        private static void StartServer()
        {
            using (WebApp.Start(Url, Configuration))
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();

                Console.WriteLine($"Server running on {Url}");

                while (true) ;
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