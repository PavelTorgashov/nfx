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
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NFX.Erlang
{
    /// <summary>
    /// TCP transport.
    /// </summary>
    public class ErlTcpTransport : IErlTransport
    {
        protected TcpClient client;

        public ErlTcpTransport()
        {
            client = new TcpClient();
        }

        public ErlTcpTransport(TcpClient client)
        {
            this.client = client;
        }

        public ErlTcpTransport(string host, int port)
        {
            client = new TcpClient(host, port);
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

        public Stream GetStream()
        {
            return client.GetStream();
        }

        public virtual void Connect(string host, int port)
        {
            client.Connect(host, port);
        }

        public void Close()
        {
            client.Close();
        }

        public void Dispose()
        {
            client.Client.Dispose();
        }

        public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, bool optionValue)
        {
            client.Client.SetSocketOption(optionLevel, optionName, optionValue);
        }

        public EndPoint RemoteEndPoint
        {
            get { return client.Client.RemoteEndPoint; }
        }
    }
}
