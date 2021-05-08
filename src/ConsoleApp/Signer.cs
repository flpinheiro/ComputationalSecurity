using System.Numerics;
using System.Security.Cryptography;
using System.Text;

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

        public static byte[] GetHash(string message)
        {
            var messageBytes = new UTF8Encoding().GetBytes(message);
            var hashValue = SHA256.Create().ComputeHash(messageBytes);
            return hashValue;
        }
    }
}
