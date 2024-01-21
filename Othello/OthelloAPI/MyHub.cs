using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

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