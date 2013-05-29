using System;
using Fleck;

namespace PetroBuzz.SuperNode
{
    public class SuperNode
    {
        public void Start()
        {
            var server = new WebSocketServer("ws://localhost:8181");

            server.Start(socket =>
                {
                    socket.OnOpen = () => Console.WriteLine("Open!");
                    socket.OnClose = () => Console.WriteLine("Close!");
                    socket.OnMessage = socket.Send;
                });
        }

        public void Send(string address, string message)
        {
            
        }
    }
}