using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NFX.SSH;

namespace NFX.Erlang
{
    /// <summary>
    /// Stream of data transmitted/received by SSH tunnel
    /// </summary>
    public class SshTunnelStream : Stream
    {
        #region Fields

        private SSHChannel          m_Channel;
        private Queue<byte>         m_IncomingData = new Queue<byte>();
        private AutoResetEvent      m_DataAvailableSignaler = new AutoResetEvent(false);

        #endregion

        #region .ctor

        public SshTunnelStream(SSHChannel channel)
        {
            this.m_Channel = channel;
        }

        #endregion

        #region Public

        /// <summary>
        /// Enqueues data to incoming queue
        /// </summary>
        public void EnqueueData(byte[] data, int offset, int count)
        {
            //copy data to incoming queue
            lock(m_IncomingData)
            for (int i = 0; i < count; i++)
                m_IncomingData.Enqueue(data[i + offset]);

            //send signal to Read method
            m_DataAvailableSignaler.Set();
        }

        /// <summary>
        /// Receives data from tunnel.
        /// If connection is closed and no data in buffer - returns 0.
        /// If tunnel is not closed and no data in buffer - blocks thread while data will be received.
        /// </summary>
        public override int Read(byte[] buffer, int offset, int count)
        {
            var hasData = false;

            //check data available
            lock (m_IncomingData)
                hasData = m_IncomingData.Count > 0;

            //if channel is closed and no data in buffer, return 0
            if (!m_Channel.Connection.IsOpen && !hasData)
                return 0;

            //wait while data will be available
            while (!hasData && m_Channel.Connection.IsOpen)
            {
                //wait for signal of data available (or recheck that connecton is open every 50 ms)
                m_DataAvailableSignaler.WaitOne(50);

                //check data available
                lock (m_IncomingData)
                    hasData = m_IncomingData.Count > 0;
            }

            //copy data from incoming queue to output buffer
            lock (m_IncomingData)
            {
                var c = Math.Min(count, m_IncomingData.Count);
                for (int i = 0; i < c; i++)
                    buffer[i + offset] = m_IncomingData.Dequeue();

                return c;
            }
        }

        /// <summary>
        /// Sends data into tunnel
        /// </summary>
        public override void Write(byte[] buffer, int offset, int count)
        {
            m_Channel.Transmit(buffer, offset, count);
        }

        /// <summary>
        /// Closes stream and tunnel
        /// </summary>
        public override void Close()
        {
            base.Close();
        }

        public override void Flush()
        {
            //nothing
        }

        public override long Length
        {
            get { throw new NotImplementedException(); }
        }

        public override long Position
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        #endregion

        #region Protected

        protected override void Dispose(bool disposing)
        {
            m_Channel.Close();
            base.Dispose(disposing);
        }

        #endregion
    }
}
