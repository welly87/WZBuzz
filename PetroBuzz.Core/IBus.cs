namespace PetroBuzz.Core
{
    public interface IBus
    {
        void Publish(string destination, IMessage message);
        void Send(string destination, IMessage message);
        void Register(string destination);
    }
}