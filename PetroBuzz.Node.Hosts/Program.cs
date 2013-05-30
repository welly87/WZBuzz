using System;

namespace PetroBuzz.Node.Hosts
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var node = new Node("tinynode");
            node.Connect("ws://localhost:9999");

            Console.WriteLine("Enter to register to tiny node");
            Console.ReadLine();

            node.Subscribe("tinynode");

            Console.ReadLine();
        }
    }
}