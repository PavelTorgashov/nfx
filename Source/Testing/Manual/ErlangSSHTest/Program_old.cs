using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFX.ApplicationModel;
using NFX.Erlang;
using NFX.SSH;
using NFX.SSH.PKI;
using NFX.SSH.SSH2;


//Start Erlang with params:
//  werl.exe -sname r@localhost -setcookie hahaha
//In erlang console:
//  register(me, self()).
//  f(M), receive M -> io:format("Got message: ~p\n", [M]) end.

namespace ErlangSSHTest
{
    class Program_old
    {
        static void Main_old(string[] args)
        {
            //here we handle password requests
            ErlTransportPasswordSource.PasswordRequired += (e) =>
            {
                if (e.UserName == "Guest")   //enter here your user account !!!!!!
                {
                    e.Password.AppendChar('g');
                    e.Password.AppendChar('u');
                    e.Password.AppendChar('e');
                    e.Password.AppendChar('s');
                    e.Password.AppendChar('t');
                    e.Password.AppendChar('1');
                    e.Password.AppendChar('2');
                    e.Password.AppendChar('3');
                    //e.Password = "123456";//password
                }
            };

            using (new ServiceBaseApplication(args, null))
            {
                var n = ErlApp.Node;
                n.AcceptConnections = false;
                n.Start();

                var m = n.CreateMbox("test");

                do
                {
                    var res = n.Send(m.Self, "r@localhost", "me", new ErlString("Hello! " + DateTime.Now));
                    if (res)
                        Console.WriteLine("Message was sent");
                    else
                        Console.WriteLine("Can not send message");

                    Console.WriteLine("Press Enter to send new message");
                    Console.ReadLine();
                } while (true);
            }
        }
    }
}
