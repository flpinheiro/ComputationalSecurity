using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class Signer
    {
        public static string Sign(PrivateKey privateKey, string message)
        {
            var hash = GetHash(message);

            return string.Empty;
        }

        public static StreamWriter Sign(PrivateKey privateKey, StreamReader sr) 
        {
            var hash = GetHash(sr);
            return new StreamWriter(Directory.GetCurrentDirectory()); ;
        }

        private static byte[] GetHash(string message)
        {
            var messageBytes = new UTF8Encoding().GetBytes(message);
            var hashValue = SHA256.Create().ComputeHash(messageBytes);
            return hashValue;
        }

        private static byte[] GetHash(StreamReader sr)
        {
            var messageBytes = new UTF8Encoding().GetBytes(sr.ReadToEnd());
            var hashValue = SHA256.Create().ComputeHash(messageBytes);
            return hashValue;
        }


    }
}
