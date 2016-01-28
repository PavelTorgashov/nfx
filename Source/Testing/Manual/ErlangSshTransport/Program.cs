using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Granados;
using Granados.PKI;
using Granados.SSH2;
using NFX.Erlang;

namespace ErlangSshTransport
{
    class Program
    {
        static void Main(string[] args)
        {
            //uncomment if you need to generate key files
            //GenerateRSAKey();

            //connect to erlang
            var n = new ErlLocalNode("b", new ErlAtom("hahaha"));
            n.AcceptConnections = false;
            n.Start();

            var m = n.CreateMbox("test");

            do
            {
                var res = n.Send(m.Self, "r@127.0.0.1", "me", new ErlString("Hello! " + DateTime.Now));
                if (!res) 
                    Console.WriteLine("Can not send message");
                else
                    Console.WriteLine("Message sent");

                Console.WriteLine("Press Enter to send new message");
                Console.ReadLine();
            } while (true);
        }

        //Tutorial: Generating a new RSA key for user authentication
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
