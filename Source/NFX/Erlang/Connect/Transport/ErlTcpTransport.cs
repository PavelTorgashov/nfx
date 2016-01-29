﻿/*<FILE_LICENSE>
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
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NFX.Environment;

namespace NFX.Erlang
{
    /// <summary>
    /// TCP transport
    /// </summary>
    public class ErlTcpTransport : IErlTransport
    {
        #region Fields

        protected TcpClient             m_Client;

        #endregion

        #region Events

        /// <summary>
        /// Transmits trace messages
        /// </summary>
        public event TraceEventHandler Trace = delegate { };

        #endregion

        #region .ctor

        public ErlTcpTransport()
        {
            m_Client = new TcpClient();
        }

        public ErlTcpTransport(TcpClient client)
        {
            this.m_Client = client;
        }

        public ErlTcpTransport(string host, int port)
        {
            m_Client = new TcpClient(host, port);
        }

        #endregion

        #region Public

        public string NodeName { get; set; }

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

        public Stream GetStream()
        {
            return m_Client.GetStream();
        }

        public virtual void Connect(string host, int port)
        {
            m_Client.Connect(host, port);
        }

        public void Close()
        {
            m_Client.Close();
        }

        public void Dispose()
        {
            m_Client.Client.Dispose();
        }

        public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, bool optionValue)
        {
            m_Client.Client.SetSocketOption(optionLevel, optionName, optionValue);
        }

        public EndPoint RemoteEndPoint
        {
            get { return m_Client.Client.RemoteEndPoint; }
        }

        public int SSHServerPort { get; set; }

        public string SSHUserName { get; set; }

        public string SSHPrivateKeyFilePath { get; set; }

        public int SSHTunnelCreationTimeout { get; set; }

        public string SSHAuthenticationType { get; set; }

        #endregion
    }
}
