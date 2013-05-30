using System;
using Fleck;
using PetroBuzz.Core;

namespace PetroBuzz.SuperNode
{
    public class SuperNode
    {
        private readonly SessionManager _sessionManager;
        private readonly TopicManager _topicManager;
        private readonly MessageSerializer _serializer;
        public SuperNode()
        {
            _sessionManager = new SessionManager();
            _topicManager = new TopicManager();
            _serializer = new MessageSerializer();
        }

        public void Start()
        {
            var server = new WebSocketServer("ws://localhost:9999");

            server.Start(socket =>
                {
                    socket.OnOpen = () =>
                        {
                            Console.WriteLine("Open!");
                            _sessionManager.Register(socket);
                        };
                    socket.OnClose = () =>
                        {
                            Console.WriteLine("Close!");
                            _sessionManager.Unregister(socket);
                        };
                    socket.OnMessage = s =>
                        {
                            HandleMessage(socket, s);
                        };
                });
        }

        private void HandleMessage(IWebSocketConnection socket, string msg)
        {
            var message = _serializer.Deserialize(msg);

            if (message.GetType() == typeof(SubscriptionMessage))
            {
                var subscriptionMsg = (SubscriptionMessage) message;
                _topicManager.Subscribe(subscriptionMsg.Topic, socket);
            }
        }

        public void Send(string address, IMessage message)
        {
            var subscriber = _topicManager.GetDestination(address);
            subscriber.Send(_serializer.Serialize(message));
        }

        public void Publish(string address, IMessage message)
        {
            var subscribers = _topicManager.GetAllSubscribers(address);

            foreach (var subscriber in subscribers)
            {
                subscriber.Send(_serializer.Serialize(message));
            }
        }
    }
}