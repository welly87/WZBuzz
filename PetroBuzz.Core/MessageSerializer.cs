using ServiceStack.Text;

namespace PetroBuzz.Core
{
    public class MessageSerializer
    {
        public IMessage Deserialize(string msg)
        {
            return JsonSerializer.DeserializeFromString<IMessage>(msg);
        }

        public string Serialize(IMessage transportMessage)
        {
            return JsonSerializer.SerializeToString(transportMessage);
        }
    }
}