using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using NFX;
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
    class Program
    {
        static void Main(string[] args)
        {
            
            //here we handle password requests
            ErlTransportPasswordSource.PasswordRequired += (ps) =>
            {
              Console.Write("Username: {0}\nPassword: ", ps.UserName);
              ps.Password = GetPassword();
              Console.WriteLine();
            };


            using (new ServiceBaseApplication(args, null))
            {
                var n = ErlApp.Node;
                n.AcceptConnections = false;
                n.Trace += (_n, t, d, text) => Console.WriteLine("{0} ({1}): {2}", t, d, text);

                n.Start();

                var cfg = App.ConfigRoot.NavigateSection("/erlang");
                var remoteName = cfg.Children.Select(nd => nd.Name == "node" ? nd.Value : string.Empty)
                                             .FirstOrDefault(s => s.Contains("@"));

                Console.WriteLine("\n\nExecute the following code on remote node {0}:", remoteName);
                Console.WriteLine("1> F = fun F() -> receive {From, Msg} -> From ! Msg, F() end end.");
                Console.WriteLine("2> spawn_link(fun() -> register(me, self()), F() end).\n");
                Console.WriteLine("Press any key when ready...");

                Console.ReadKey();

                var m = n.CreateMbox("test");
                var a = new ErlAtom("hello");
                var msg = new ErlTuple(m.Self, a);
                var remoteNode = new ErlAtom(remoteName);

                DateTime empty = new DateTime(2000, 1, 1, 0, 0, 0);
                DateTime start = empty;
                long count = 0;
                long msgs = 30000;

                do
                {
                    var res = n.Send(m.Self, remoteNode, "me", msg);
                    if (!res)
                    {
                        Console.WriteLine("Can not send message");
                        break;
                    }

                    if (start == empty)
                        start = DateTime.UtcNow;

                    var got = m.Receive(5000);

                    if (!got.Equals((IErlObject)a))
                    {
                        Console.WriteLine("Got wrong result! Expected: {0}, Got: {1}", a, got);
                        count = -1;
                        break;
                    }

                    count++;

                    if ((count % 10000) == 0)
                        Console.WriteLine("Processed {0} messages", count);
                    //Console.ReadLine();
                } while (count < msgs);

                var end = DateTime.UtcNow;
                var diff = (end - start);

                if (count > 0)
                    Console.WriteLine("Processed {0} messages. Speed: {1:F2}msgs/s, Latency: {2}us",
                        msgs, msgs / diff.TotalSeconds, 1000.0 * diff.TotalMilliseconds / msgs);
            }

            if (Debugger.IsAttached)
                Console.ReadKey();
        }

        public static SecureString GetPassword()
        {
            SecureString pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }
    }
}