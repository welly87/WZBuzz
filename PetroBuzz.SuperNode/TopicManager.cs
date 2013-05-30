using Fleck;
using System.Collections.Generic;
using System.Linq;

namespace PetroBuzz.SuperNode
{
    class TopicManager
    {
        // TODO change to concurrent collection
        readonly IDictionary<string, IList<IWebSocketConnection>> _subscribers = new Dictionary<string, IList<IWebSocketConnection>>();

        internal void Subscribe(string topic, IWebSocketConnection socket)
        {
            if (_subscribers.ContainsKey(topic))
            {
                _subscribers[topic].Add(socket);
            }
            else
            {
                _subscribers.Add(topic, new List<IWebSocketConnection> { socket });
            }
        }

        internal IWebSocketConnection GetDestination(string address)
        {
            if (_subscribers.ContainsKey(address))
            {
                return _subscribers[address].FirstOrDefault();
            }

            return null;
        }

        internal IEnumerable<IWebSocketConnection> GetAllSubscribers(string address)
        {
            if (_subscribers.ContainsKey(address))
            {
                return _subscribers[address];
            }
            return new List<IWebSocketConnection>();
        }
    }
}
