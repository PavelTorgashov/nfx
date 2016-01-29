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
    class Program
    {
        static void Main(string[] args)
        {
            //----uncomment if you need to generate SSH2 key files-----
            //GenerateRSAKey();

            //here we handle password requests
            ErlTransportPasswordSource.PasswordRequired += (o, e) =>
            {
                if(e.UserName == "Guest")   //enter here your user account
                    e.Password = "guest123";//and your user password
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

        //Generating a new RSA key for user authentication
        private static void GenerateRSAKey()
        {
            //RSA KEY GENERATION TEST
            byte[] testdata = Encoding.ASCII.GetBytes("CHRISTIAN VIERI");
            RSAKeyPair kp = RSAKeyPair.GenerateNew(2048, RngManager.GetSecureRng());

            //sign and verify test
            byte[] sig = kp.Sign(testdata);
            kp.Verify(sig, testdata);

            //export / import test
            SSH2UserAuthKey key = new SSH2UserAuthKey(kp);
            key.WritePublicPartInOpenSSHStyle(new FileStream("c:\\key.pub", FileMode.Create));
            key.WritePrivatePartInSECSHStyleFile(new FileStream("c:\\key.bin", FileMode.Create), "comment", "123456");
            //read test
            SSH2UserAuthKey newpk = SSH2UserAuthKey.FromSECSHStyleFile("c:\\key.bin", "123456");
        }
    }
}
