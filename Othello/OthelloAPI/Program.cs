using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;

namespace Othello //THIS IS ACTUALLY THE SERVER
{
    public class Program
    {
        private const string Url = "http://localhost:9082";
        public const string connectionString = "Server=localhost; Database=OTHELLO_DB; Trusted_Connection=True;";

        public List<string> messages = new List<string>();

        private static void Main(string[] args)
        {
            Console.WriteLine("Server started");

            using (WebApp.Start(Url, Configuration))
            {
                string message;
                bool dc = false;
                var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();

                Console.WriteLine($"Server running on {Url}");
                Console.WriteLine("Type a message and press enter to send, \"q\" to disconnect");

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

                foreach(string _message in MyHub.messages)
                {
                    Console.WriteLine(_message);
                }

                Console.ReadLine();
            }
        }

        public static void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}