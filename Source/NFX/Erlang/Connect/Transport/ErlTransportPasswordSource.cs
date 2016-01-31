using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace NFX.Erlang
{
    /// <summary>
    /// Source of passwrod for transport (i.e. for SSH connection)
    /// </summary>
    /// <remarks>
    /// When IErlTransport requires password, it will call method GetPassword() of this class.
    /// The app must to handle event PasswordRequired to return password.
    /// </remarks>
    public static class ErlTransportPasswordSource
    {
        #region Fields

        private static Dictionary<ErlPasswordSession, ErlPasswordSession>   m_passCache = new Dictionary<ErlPasswordSession, ErlPasswordSession>();

        #endregion

        #region Events

        /// <summary>
        /// Called when SSH(or other secure tansport) user password (or private key file passphrase) is required.
        /// Handler must to return password for specified userName and nodeName
        /// </summary>
        public static event ErlPasswordRequiredEventHandler PasswordRequired;

        #endregion

        #region Public static

        /// <summary>
        /// Returns password for specified userName and nodeName
        /// </summary>
        public static string GetPassword(object sender, string nodeName, string userName)
        {
            ErlPasswordSession res = null;
            var inCache = false;

            //check cache
            lock (m_passCache)
                inCache = m_passCache.TryGetValue(new ErlPasswordSession(nodeName, userName), out res);

            if (inCache)
            {
                if (res.Password == null)
                {
                    //ask user about password
                    if (PasswordRequired != null)
                        PasswordRequired(res);
                }

                return SecureStringToString(res.Password);
            }

            throw new ErlException("Password session is not started");
        }

        /// <summary>
        /// Starts cache session of password
        /// </summary>
        public static ErlPasswordSession StartPasswordSession(string nodeName, string userName)
        {
            var ps = new ErlPasswordSession(nodeName, userName);

            //cahce contains this node already, so return fake ErlPasswordSession

            lock (m_passCache)
            {
                if (m_passCache.ContainsKey(ps))
                    return ps;

                //add to cache
                m_passCache.Add(ps, ps);
            }

            return ps;
        }

        #endregion

        #region Private

        static String SecureStringToString(SecureString value)
        {
            if (value == null)
                return null;

            IntPtr bstr = Marshal.SecureStringToBSTR(value);

            try
            {
                return Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                Marshal.FreeBSTR(bstr);
            }
        }

        #endregion
    }

    /// <summary>
    /// Delegate is called when SSH tunnel requires password for authentication
    /// </summary>
    public delegate void ErlPasswordRequiredEventHandler(ErlPasswordSession session);

    /// <summary>
    /// Keeps password for node and user
    /// </summary>
    public class ErlPasswordSession : IDisposable
    {
        #region Public

        public string NodeName { get; private set; }
        public string UserName { get; private set; }
        public SecureString Password { get; set; }

        public void Dispose()
        {
            if (Password != null)
                Password.Dispose();//dispose Password
        }

        public override int GetHashCode()
        {
            return NodeName.GetHashCode() ^ UserName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as ErlPasswordSession;
            if (other == null)
                return false;
            return NodeName == other.NodeName && UserName == other.UserName;
        }

        #endregion

        #region .ctor

        internal ErlPasswordSession(string nodeName, string userName)
        {
            NodeName = nodeName ?? "";
            UserName = userName ?? "";
        }

        #endregion
    }
}
