using System;
using PetroBuzz.Core;
using SuperSocket.ClientEngine;
using WebSocket4Net;

namespace PetroBuzz.Node
{
    public class Node
    {
        private WebSocket _websocket;
        private string _nodeName;
        private MessageSerializer _serializer;

        public Node(string nodeName)
        {
            _nodeName = nodeName;
            _serializer = new MessageSerializer();
        }

        public void Connect(string address)
        {
            _websocket = new WebSocket(address);
            _websocket.Opened += websocket_Opened;
            _websocket.Error += websocket_Error;
            _websocket.Closed += websocket_Closed;
            _websocket.MessageReceived += websocket_MessageReceived;

            _websocket.Open();
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
            //_websocket.Send("Hai from client"); // register default nodes
        }

        public void Subscribe(string destination)
        {
            var message = new SubscriptionMessage
                {
                    Topic = destination
                };

            _websocket.Send(_serializer.Serialize(message));
        }
    }
}