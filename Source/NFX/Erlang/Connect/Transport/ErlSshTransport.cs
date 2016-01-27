/*<FILE_LICENSE>
* NFX (.NET Framework Extension) Unistack Library
* Copyright 2003-2014 IT Adapter Inc / 2015 Aum Code LLC
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
</FILE_LICENSE>*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Granados;
using Granados.PKI;

namespace NFX.Erlang
{
    /// <summary>
    /// SSH tunnel transport.
    /// Provides tcp connection through SSH tunnel.
    /// </summary>
    public class ErlSshTransport : IErlTransport, ISSHConnectionEventReceiver, ISSHChannelEventReceiver
    {
        Socket client;
        SSHConnection conn;
        SSHChannel channel;
        SshTunnelStream stream;
        IPEndPoint remoteTarget;
        bool ready;

        const int DEFAULT_SSH_PORT = 22;

        /// <summary>
        /// Port of SSH server (by default: 22)
        /// </summary>
        public int SSHServerPort { get; set; }
        /// <summary>
        /// Host of SSH server (by default: same as target host)
        /// </summary>
        public string SSHServerHost { get; set; }
        /// <summary>
        /// SSH user name
        /// </summary>
        public string SSHUserName { get; set; }
        /// <summary>
        /// SSH user password
        /// </summary>
        public string SSHUserPassword { get; set; }
        /// <summary>
        /// Identity key file path (only for AuthenticationType = PublicKey)
        /// </summary>
        public string SSHKeyFilePath { get; set; }
        /// <summary>
        /// Type of auth on SSH server
        /// </summary>
        public AuthenticationType AuthenticationType { get; set; }

        public ErlSshTransport()
        {
            //default settings
            AuthenticationType = AuthenticationType.Password;
            SSHServerPort = DEFAULT_SSH_PORT;
            //create socket
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// Connect to remote host:port over SSH tunnel
        /// </summary>
        public void Connect(string host, int port)
        {
            Console.WriteLine("Ssh tunnel: {0}:{1}", host, port);//temp !!!!!

            //remember remote target
            remoteTarget = new IPEndPoint(ResolveHost(host), port);

            //connect to SSH server
            var sshHost = string.IsNullOrEmpty(SSHServerHost) ? host : SSHServerHost;
            client.Connect(new IPEndPoint(ResolveHost(sshHost), SSHServerPort));

            //set params
            var param = new SSHConnectionParameter();
            param.EventTracer = new Tracer(); //to receive detailed events, set ISSHEventTracer
            param.UserName = SSHUserName;
            param.Password = SSHUserPassword;
            param.Protocol = SSHProtocol.SSH2;
            param.AuthenticationType = AuthenticationType;
            if (AuthenticationType == Granados.AuthenticationType.PublicKey)
                param.IdentityFile = SSHKeyFilePath;

            //former algorithm is given priority in the algorithm negotiation
            param.PreferableHostKeyAlgorithms = new PublicKeyAlgorithm[] { PublicKeyAlgorithm.DSA, PublicKeyAlgorithm.RSA };
            param.PreferableCipherAlgorithms = new CipherAlgorithm[] { CipherAlgorithm.Blowfish, CipherAlgorithm.TripleDES, CipherAlgorithm.AES192CTR };

            param.WindowSize = 0x1000; //this option is ignored with SSH1

            //Creating a new SSH connection over the underlying socket
            conn = SSHConnection.Connect(param, this, client);
            conn.AutoDisconnect = true;

            //Local->Remote port forwarding (we use localhost:0 as local port, because local port is not required for us, we will use this tunnel directly)
            channel = conn.ForwardPort(this, host, port, "localhost", 0);
            while (!ready)
                System.Threading.Thread.Sleep(50); //wait response

            //create network stream
            stream = new SshTunnelStream(channel);

            //Remote->Local
            // if you want to listen to a port on the SSH server, follow this line:
            //_conn.ListenForwardedPort("0.0.0.0", 10000);

            //NOTE: if you use SSH2, dynamic key exchange feature is supported.
            //((SSH2Connection)_conn).ReexchangeKeys();
        }

        static IPAddress ResolveHost(string hostname)
        {
            try
            {
                return IPAddress.Parse(hostname);
            }
            catch (FormatException)
            {
                return Dns.GetHostAddresses(hostname)[0];
            }
        }

        #region IErlTransport

        public Stream GetStream()
        {
            return stream;
        }

        public int ReceiveBufferSize
        {
            get
            {
                return client.ReceiveBufferSize;
            }
            set
            {
                client.ReceiveBufferSize = value;
            }
        }

        public int SendBufferSize
        {
            get
            {
                return client.SendBufferSize;
            }
            set
            {
                client.SendBufferSize = value;
            }
        }

        public bool NoDelay
        {
            get
            {
                return client.NoDelay;
            }
            set
            {
                client.NoDelay = value;
            }
        }

        public void Close()
        {
            client.Close();
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, bool optionValue)
        {
            client.SetSocketOption(optionLevel, optionName, optionValue);
        }

        public EndPoint RemoteEndPoint
        {
            get { return remoteTarget; }
        }

        #endregion

        #region ISSHConnectionEventReceiver, ISSHChannelEventReceiver

        public void OnData(byte[] data, int offset, int length)
        {
            if (length > 0)
            lock (stream.IncomingData)
                for (int i = 0; i < length; i++)
                    stream.IncomingData.Enqueue(data[i + offset]);
        }

        public void OnDebugMessage(bool always_display, byte[] data)
        {
            Debug.Write("DEBUG: " + Encoding.ASCII.GetString(data) + "\r\n");
        }

        public void OnIgnoreMessage(byte[] data)
        {
            Debug.Write("Ignore: " + Encoding.ASCII.GetString(data) + "\r\n");
        }

        public void OnAuthenticationPrompt(string[] msg)
        {
            Debug.Write("Auth Prompt " + (msg.Length > 0 ? msg[0] : "(empty)") + "\r\n");
        }

        public void OnError(Exception error)
        {
            Debug.Write("ERROR: " + error.Message + "\r\n");
            Debug.Write(error.StackTrace + "\r\n");
        }

        public void OnChannelClosed()
        {
            Debug.Write("Channel closed" + "\r\n");
            //_conn.AsyncReceive(this);
        }

        public void OnChannelEOF()
        {
            channel.Close();
            Debug.Write("Channel EOF" + "\r\n");
            //close connection
            conn.Close();
        }

        public void OnExtendedData(int type, byte[] data)
        {
            Debug.Write("EXTENDED DATA" + "\r\n");
        }

        public void OnConnectionClosed()
        {
            Debug.Write("Connection closed" + "\r\n");
        }

        public void OnUnknownMessage(byte type, byte[] data)
        {
            Debug.Write("Unknown Message " + type + "\r\n");
        }

        public void OnChannelReady()
        {
            ready = true;
        }

        public void OnChannelError(Exception error)
        {
            Debug.Write("Channel ERROR: " + error.Message + "\r\n");
        }

        public void OnMiscPacket(byte type, byte[] data, int offset, int length)
        {
        }

        public PortForwardingCheckResult CheckPortForwardingRequest(string host, int port, string originator_host, int originator_port)
        {
            PortForwardingCheckResult r = new PortForwardingCheckResult();
            r.allowed = true;
            r.channel = this;
            return r;
        }

        public void EstablishPortforwarding(ISSHChannelEventReceiver rec, SSHChannel channel)
        {
            this.channel = channel;
        }

        #endregion
    }


    class Tracer : ISSHEventTracer
    {
        public void OnTranmission(string type, string detail)
        {
            Debug.Write("T:" + type + ":" + detail + "\r\n");
        }
        public void OnReception(string type, string detail)
        {
            Debug.Write("R:" + type + ":" + detail + "\r\n");
        }
    }
}
