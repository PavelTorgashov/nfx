/*
 Copyright (c) 2005 Poderosa Project, All Rights Reserved.
 This file is a part of the Granados SSH Client Library that is subject to
 the license included in the distributed package.
 You may not use this file except in compliance with the license.

 $Id: ConnectionParameter.cs,v 1.5 2011/10/27 23:21:56 kzmi Exp $
*/

using System;
using System.Text;
using System.Security.Cryptography;

using NFX.SSH.PKI;
using NFX.SSH.Util;
using NFX.SSH.IO;

namespace NFX.SSH {
    /// <summary>
    /// ConnectionInfo describes the attributes of the host or the connection.
    /// It is available after the connection is established without any errors.
    /// </summary>
    /// <exclude/>
    public abstract class SSHConnectionInfo {
        internal string _serverVersionString;
        internal string _clientVersionString;
        internal string _supportedCipherAlgorithms;
        internal PublicKey _hostkey;

        internal CipherAlgorithm _algorithmForTransmittion;
        internal CipherAlgorithm _algorithmForReception;

        public string ServerVersionString {
            get {
                return _serverVersionString;
            }
        }
        public string ClientVerisonString {
            get {
                return _clientVersionString;
            }
        }
        public string SupportedCipherAlgorithms {
            get {
                return _supportedCipherAlgorithms;
            }
        }
        public CipherAlgorithm AlgorithmForTransmittion {
            get {
                return _algorithmForTransmittion;
            }
        }
        public CipherAlgorithm AlgorithmForReception {
            get {
                return _algorithmForReception;
            }
        }
        public PublicKey HostKey {
            get {
                return _hostkey;
            }
        }

        public abstract string DumpHostKeyInKnownHostsStyle();

        public abstract byte[] HostKeyMD5FingerPrint();
        public abstract byte[] HostKeySHA1FingerPrint();

    }
}

namespace NFX.SSH.SSH2 {
    using NFX.SSH.PKI;
    using NFX.SSH.IO.SSH2;

    /// <summary>
    /// 
    /// </summary>
    /// <exclude/>
    public class SSH2ConnectionInfo : SSHConnectionInfo {
        internal string _supportedHostKeyAlgorithms;
        internal PublicKeyAlgorithm _algorithmForHostKeyVerification;
        internal string _supportedKEXAlgorithms;
        internal KexAlgorithm _kexAlgorithm = KexAlgorithm.None;

        public string SupportedHostKeyAlgorithms {
            get {
                return _supportedHostKeyAlgorithms;
            }
        }

        public PublicKeyAlgorithm AlgorithmForHostKeyVerification {
            get {
                return _algorithmForHostKeyVerification;
            }
        }
        public string SupportedKEXAlgorithms {
            get {
                return _supportedKEXAlgorithms;
            }
        }
        public KexAlgorithm UsingKEXAlgorithms {
            get {
                return _kexAlgorithm;
            }
        }
        public override string DumpHostKeyInKnownHostsStyle() {
            StringBuilder bld = new StringBuilder();
            bld.Append(SSH2Util.PublicKeyAlgorithmName(_hostkey.Algorithm));
            bld.Append(' ');
            bld.Append(Encoding.ASCII.GetString(Base64.Encode(WriteToDataWriter())));
            return bld.ToString();
        }

        public override byte[] HostKeyMD5FingerPrint() {
            return new MD5CryptoServiceProvider().ComputeHash(WriteToDataWriter());
        }
        public override byte[] HostKeySHA1FingerPrint() {
            return new SHA1CryptoServiceProvider().ComputeHash(WriteToDataWriter());
        }

        private byte[] WriteToDataWriter() {
            SSH2DataWriter wr = new SSH2DataWriter();
            wr.WriteString(SSH2Util.PublicKeyAlgorithmName(_hostkey.Algorithm));
            if (_hostkey.Algorithm == PublicKeyAlgorithm.RSA) {
                RSAPublicKey rsa = (RSAPublicKey)_hostkey;
                wr.WriteBigInteger(rsa.Exponent);
                wr.WriteBigInteger(rsa.Modulus);
            }
            else if (_hostkey.Algorithm == PublicKeyAlgorithm.DSA) {
                DSAPublicKey dsa = (DSAPublicKey)_hostkey;
                wr.WriteBigInteger(dsa.P);
                wr.WriteBigInteger(dsa.Q);
                wr.WriteBigInteger(dsa.G);
                wr.WriteBigInteger(dsa.Y);
            }
            else
                throw new SSHException("Host key algorithm is unsupported");

            return wr.ToByteArray();
        }

    }
}

