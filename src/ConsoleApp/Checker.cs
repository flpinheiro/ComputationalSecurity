using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class Checker
    {
        public static bool Vrfy(PublicKey publicKey, RSAMessage message) 
        {
            var hash = Signer.GetHash(message.Message);

            var hashCheck = BigInteger.ModPow(message.Sigma, publicKey.E, publicKey.N).ToByteArray();

            var hashInt = new BigInteger(hash);
            var hashCheckInt = new BigInteger(hashCheck);

            return hashInt.Equals(hashCheckInt) ;
        }
    }
}
