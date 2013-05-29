using System;

namespace PetroBuzz.SuperNode.Hosts
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var superNode = new SuperNode();
            superNode.Start();

            Console.WriteLine("SuperNode started.. Enter to send to tiny node");

            Console.ReadLine();

            superNode.Send("tinynode", "hello world");
        }
    }
}