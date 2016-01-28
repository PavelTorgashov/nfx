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
using NFX.Environment;

namespace NFX.Erlang
{
    /// <summary>
    /// SSH tunnel transport.
    /// Provides tcp connection through SSH tunnel.
    /// </summary>
    public class ErlSshTransport : IErlTransport, ISSHConnectionEventReceiver, ISSHChannelEventReceiver, ISSHEventTracer, IConfigurable
    {
        #region CONSTS / Enums

        private const int DEFAULT_SSH_PORT                      = 22;
        private const int DEFAULT_SSH_TUNNEL_CREATION_TIMEOUT   = 20000;//ms

        #endregion;

        #region Static

        static IPAddress ResolveHost(string hostname)
        {
            IPAddress res;

            if (!IPAddress.TryParse(hostname, out res))
                res = Dns.GetHostAddresses(hostname)[0];

            return res;
        }

        #endregion

        #region Fields

        private Socket          m_Client;
        private SSHConnection   m_Connection;
        private SSHChannel      m_Channel;
        private SshTunnelStream m_Stream;
        private IPEndPoint      m_RemoteTarget;
        private bool            m_IsChannelReady;

        #endregion;

        #region Events

        /// <summary>
        /// Transmits trace messages
        /// </summary>
        public event TraceEventHandler Trace = delegate { };

        #endregion

        #region .ctor

        public ErlSshTransport()
        {
            //default settings
            AuthenticationType = AuthenticationType.Password;
            SSHServerPort = DEFAULT_SSH_PORT;
            SSHTunnelCreationTimeout = DEFAULT_SSH_TUNNEL_CREATION_TIMEOUT;
            //create socket
            m_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        #endregion

        #region Public

        /// <summary>
        /// Port of SSH server (by default: 22)
        /// </summary>
        [Config]
        public int SSHServerPort { get; set; }
        /// <summary>
        /// SSH user name
        /// </summary>
        [Config]
        public string SSHUserName { get; set; }
        /// <summary>
        /// SSH user password (or private key file passphrase)
        /// </summary>
        [Config]
        public string SSHUserPassword { get; set; }
        /// <summary>
        /// Private key file path (only for AuthenticationType = PublicKey)
        /// Required SSH2 ENCRYPTED PRIVATE KEY format.
        /// </summary>
        [Config]
        public string SSHPrivateKeyFilePath { get; set; }
        /// <summary>
        /// Timeout of creation of SSH tunnel, ms (by default: 20000 ms)
        /// </summary>
        [Config]
        public int SSHTunnelCreationTimeout { get; set; }
        /// <summary>
        /// Type of auth on SSH server
        /// </summary>
        [Config]
        public AuthenticationType AuthenticationType { get; set; }

        /// <summary>
        /// Connect to remote host:port over SSH tunnel
        /// </summary>
        public void Connect(string host, int port)
        {
            Console.WriteLine("Ssh tunnel: {0}:{1}", host, port);//temp !!!!!

            try
            {

                //remember remote target
                m_RemoteTarget = new IPEndPoint(ResolveHost(host), port);

                //connect to SSH server
                m_Client.Connect(new IPEndPoint(m_RemoteTarget.Address, SSHServerPort));

                //set params
                var param = new SSHConnectionParameter();
                param.EventTracer = this; //to receive detailed events
                param.UserName = SSHUserName;
                param.Password = SSHUserPassword;
                param.Protocol = SSHProtocol.SSH2;
                param.AuthenticationType = AuthenticationType;

                if (AuthenticationType == AuthenticationType.PublicKey)
                    param.IdentityFile = SSHPrivateKeyFilePath;

                //former algorithm is given priority in the algorithm negotiation
                param.PreferableHostKeyAlgorithms = new PublicKeyAlgorithm[] { PublicKeyAlgorithm.RSA, PublicKeyAlgorithm.DSA };
                param.PreferableCipherAlgorithms = new CipherAlgorithm[] { CipherAlgorithm.Blowfish, CipherAlgorithm.TripleDES, CipherAlgorithm.AES192CTR, CipherAlgorithm.AES256CTR, CipherAlgorithm.AES128CTR };

                param.WindowSize = 0x1000; //this option is ignored with SSH1

                //Creating a new SSH connection over the underlying socket
                m_Connection = SSHConnection.Connect(param, this, m_Client);
                m_Connection.AutoDisconnect = true;
                m_IsChannelReady = false;

                //Local->Remote port forwarding (we use localhost:0 as local port, because local port is not required for us, we will use this tunnel directly)
                m_Channel = m_Connection.ForwardPort(this, host, port, "localhost", 0);
                var deadLine = DateTime.Now.AddMilliseconds(SSHTunnelCreationTimeout);
                while (!m_IsChannelReady && deadLine > DateTime.Now)
                    System.Threading.Thread.Sleep(50); //wait response

                //if timeouted - throw exception
                if (!m_IsChannelReady && deadLine < DateTime.Now)
                    throw new ErlException(StringConsts.ERL_CREATE_SSH_TUNNEL_ERROR);

                //create network stream
                m_Stream = new SshTunnelStream(m_Channel);

                //Remote->Local
                // if you want to listen to a port on the SSH server, follow this line:
                //_conn.ListenForwardedPort("0.0.0.0", 10000);

                //NOTE: if you use SSH2, dynamic key exchange feature is supported.
                //((SSH2Connection)_conn).ReexchangeKeys();
            }
            catch (Exception ex)
            {
                OnTrace(ErlTraceLevel.Ctrl, Direction.Inbound, ex.Message);
                throw;
            }
        }

        public Stream GetStream()
        {
            return m_Stream;
        }

        public int ReceiveBufferSize
        {
            get
            {
                return m_Client.ReceiveBufferSize;
            }
            set
            {
                m_Client.ReceiveBufferSize = value;
            }
        }

        public int SendBufferSize
        {
            get
            {
                return m_Client.SendBufferSize;
            }
            set
            {
                m_Client.SendBufferSize = value;
            }
        }

        public bool NoDelay
        {
            get
            {
                return m_Client.NoDelay;
            }
            set
            {
                m_Client.NoDelay = value;
            }
        }

        public void Close()
        {
            m_Client.Close();
        }

        public void Dispose()
        {
            m_Client.Dispose();
        }

        public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, bool optionValue)
        {
            m_Client.SetSocketOption(optionLevel, optionName, optionValue);
        }

        public EndPoint RemoteEndPoint
        {
            get { return m_RemoteTarget; }
        }

        public void OnData(byte[] data, int offset, int length)
        {
            if (length > 0)
            lock (m_Stream.IncomingData)
                for (int i = 0; i < length; i++)
                    m_Stream.IncomingData.Enqueue(data[i + offset]);
        }

        public void OnDebugMessage(bool always_display, byte[] data)
        {
            OnTrace(ErlTraceLevel.Ctrl, Direction.Inbound, "DEBUG: " + Encoding.ASCII.GetString(data));
        }

        public void OnIgnoreMessage(byte[] data)
        {
            OnTrace(ErlTraceLevel.Ctrl, Direction.Inbound, "Ignore: " + Encoding.ASCII.GetString(data));
        }

        public void OnAuthenticationPrompt(string[] msg)
        {
            OnTrace(ErlTraceLevel.Ctrl, Direction.Inbound, "Auth Prompt " + (msg.Length > 0 ? msg[0] : "(empty)"));
        }

        public void OnError(Exception error)
        {
            OnTrace(ErlTraceLevel.Ctrl, Direction.Inbound, "ERROR: " + error.Message);
        }

        public void OnChannelClosed()
        {
            OnTrace(ErlTraceLevel.Ctrl, Direction.Inbound, "Channel closed");
            //_conn.AsyncReceive(this);
        }

        public void OnChannelEOF()
        {
            m_Channel.Close();

            OnTrace(ErlTraceLevel.Ctrl, Direction.Inbound, "Channel EOF");
            //close connection
            m_Connection.Close();
        }

        public void OnExtendedData(int type, byte[] data)
        {
            OnTrace(ErlTraceLevel.Ctrl, Direction.Inbound, "EXTENDED DATA");
        }

        public void OnConnectionClosed()
        {
            OnTrace(ErlTraceLevel.Ctrl, Direction.Inbound, "Connection closed");
        }

        public void OnUnknownMessage(byte type, byte[] data)
        {
            OnTrace(ErlTraceLevel.Ctrl, Direction.Inbound, "Unknown Message " + type);
        }

        public void OnChannelReady()
        {
            m_IsChannelReady = true;
            OnTrace(ErlTraceLevel.Ctrl, Direction.Inbound, "Channel Ready");
        }

        public void OnChannelError(Exception error)
        {
            OnTrace(ErlTraceLevel.Ctrl, Direction.Inbound, "Channel ERROR: " + error.Message);
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
            this.m_Channel = channel;
        }

        public void OnTranmission(string type, string detail)
        {
            OnTrace(ErlTraceLevel.Ctrl, Direction.Outbound, "T:" + type + ":" + detail);
        }

        public void OnReception(string type, string detail)
        {
            OnTrace(ErlTraceLevel.Ctrl, Direction.Inbound, "R:" + type + ":" + detail);
        }

        public void Configure(IConfigSectionNode node)
        {
        }

        #endregion

        #region Private

        private void OnTrace(ErlTraceLevel level, Direction dir, string message)
        {
            Console.WriteLine(message);//temp!!!!
            Trace(this, level, dir, "SSH " + message);
        }

        #endregion
    }
}
