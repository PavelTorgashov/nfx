using System;
using System.Collections.Generic;
using System.Linq;
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
        #region Events

        /// <summary>
        /// Called when SSH(or other secure tansport) user password (or private key file passphrase) is required.
        /// Handler must to return password for specified userName and nodeName
        /// </summary>
        public static event PasswordRequiredEventHandler PasswordRequired;

        #endregion

        #region Public static

        /// <summary>
        /// Returns password for specified userName and nodeName
        /// </summary>
        public static string GetPassword(object sender, string nodeName, string userName)
        {
            var args = new PasswordRequiredEventArgs(nodeName, userName);
            if (PasswordRequired != null)
                PasswordRequired(sender, args);
            return args.Password;
        }

        #endregion
    }

    /// <summary>
    /// Delegate is called when SSH tunnel requires password for authentication
    /// </summary>
    public delegate void PasswordRequiredEventHandler(object sender, PasswordRequiredEventArgs args);

    public class PasswordRequiredEventArgs : EventArgs
    {
        #region Public

        public string NodeName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; set; }

        #endregion

        #region .ctor

        public PasswordRequiredEventArgs(string nodeName, string userName)
        {
            NodeName = nodeName;
            UserName = userName;
        }

        #endregion
    }
}
