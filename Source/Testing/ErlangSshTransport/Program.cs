using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFX.Erlang;

namespace ErlangSshTransport
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = new ErlLocalNode("b", new ErlAtom("hahaha"));
            n.AcceptConnections = false;
            n.Start();

            var m = n.CreateMbox("test");

            do
            {
                n.Send(m.Self, "r@127.0.0.1", "me", new ErlString("Hello! " + DateTime.Now));
                Console.WriteLine("Message sent");
                Console.WriteLine("Press Enter to send new message");
                Console.ReadLine();
            } while (true);
        }
    }
}
