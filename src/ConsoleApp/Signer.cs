using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class Signer
    {
        public static RSAMessage Sign(PrivateKey privateKey, string message)
        {
            var hash = GetHash(message);
            var sigma = BigInteger.ModPow(new BigInteger(hash), privateKey.D, privateKey.N);
            var ret = new RSAMessage(message, sigma);
            return ret;
        }

        public static StreamWriter Sign(PrivateKey privateKey, StreamReader sr) 
        {
            var ret = Sign(privateKey,sr.ReadToEnd());
            var stream = new StreamWriter(Directory.GetCurrentDirectory());
            stream.Write(ret.Message);
            return stream;
        }

        public static byte[] GetHash(string message)
        {
            var messageBytes = new UTF8Encoding().GetBytes(message);
            var hashValue = SHA256.Create().ComputeHash(messageBytes);
            return hashValue;
        }
    }
}
