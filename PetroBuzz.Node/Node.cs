using System;
using SuperSocket.ClientEngine;
using WebSocket4Net;

namespace PetroBuzz.Node
{
    public class Node
    {
        private WebSocket websocket;

        public void Connect(string p)
        {
            websocket = new WebSocket(p);
            websocket.Opened += websocket_Opened;
            websocket.Error += websocket_Error;
            websocket.Closed += websocket_Closed;
            websocket.MessageReceived += websocket_MessageReceived;

            websocket.Open();
        }

        private void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private void websocket_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Closed");
        }

        private void websocket_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
        }

        private void websocket_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Opened");
            websocket.Send("Hai from client");
        }

        public void Subscribe(string destination)
        {
            
        }
    }
}