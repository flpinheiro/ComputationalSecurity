using System.IO;
using System.Numerics;
using UnB.Security.Domain;

namespace UnB.Security.Services
{
    public static class Checker
    {
        public static bool Vrfy(PublicKey publicKey, RSAMessage message)
        {
            var hash = Signer.GetHash(message.Message);

            var hashCheck = BigInteger.ModPow(message.Sigma, publicKey.E, publicKey.N).ToByteArray();

            var hashInt = new BigInteger(hash);
            var hashCheckInt = new BigInteger(hashCheck);

            return hashInt.Equals(hashCheckInt);
        }

        public static bool VrfyFile(PublicKey publicKey, StreamReader sr)
        {
            var str = sr.ReadToEnd();

            var split = str.Split("@%@");

            RSAMessage message = new RSAMessage(split[1], BigInteger.Parse(split[0]));
            return Vrfy(publicKey, message);
        }
    }
}
