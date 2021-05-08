using System;
using System.Numerics;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var rsa = Generator.GenRSA();
            Console.WriteLine(rsa);

            var sigma = BigInteger.ModPow(158,rsa.PrivateKey.D, rsa.PrivateKey.N);
            Console.WriteLine(sigma);
            var m = BigInteger.ModPow(sigma, rsa.PublicKey.E, rsa.PrivateKey.N);
            Console.WriteLine(m);


            var hashRSA = Signer.Sign(rsa.PrivateKey, "Bela noite de verão");

            Console.WriteLine(hashRSA);

            var result = Checker.Vrfy(rsa.PublicKey,hashRSA);
            Console.WriteLine(result);
        }
    }

}
