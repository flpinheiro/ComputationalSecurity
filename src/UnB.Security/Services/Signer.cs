using System;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using UnB.Security.Domain;

namespace UnB.Security.Services
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

        public static byte[] GetHash(string message)
        {
            var messageBytes = new UTF8Encoding().GetBytes(message);
            var hashValue = SHA256.Create().ComputeHash(messageBytes);
            return hashValue;
        }
        public static FileStream SignFile(PrivateKey privateKey, StreamReader sr)
        {
            var message = sr.ReadToEnd();

            var hashRSA = Sign(privateKey, message);

            //@% hasg %@
            //text
            var path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "upload.txt");

            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            //Create the file.
            FileStream fs;
            using (fs = File.Create(path))
            {
                AddText(fs, $"{hashRSA.Sigma}@%@");
                AddText(fs, message);
            }

            return fs;
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
