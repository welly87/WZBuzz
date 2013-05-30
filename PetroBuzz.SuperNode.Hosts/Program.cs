using System;
using PetroBuzz.Core;

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

            //superNode.Send("tinynode", new SimpleMessage
            //    {
            //        Message = "My very simple message"
            //    });

            superNode.Publish("tinynode", new SimpleMessage
            {
                Message = "My very simple message"
            });


            Console.ReadLine();
        }
    }
}