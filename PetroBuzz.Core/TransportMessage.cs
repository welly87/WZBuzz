
namespace PetroBuzz.Core
{
    public class TransportMessage
    {
        public string MessageType { get; set; }
        public IMessage Message { get; set; }
    }
}
