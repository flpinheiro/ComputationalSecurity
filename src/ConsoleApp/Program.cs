using System;
using System.Numerics;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var rsa = Generator.GenRSA();

            var sign = Signer.Sign(rsa.PrivateKey, "bela noite de verão");

            var test = Checker.Vrfy(rsa.PublicKey, sign);
            Console.WriteLine(test);

            var big = new BigInteger(12345678901234567890);
            rsa = Generator.GenRSA(big.ToByteArray().Length);

            Console.WriteLine(big);
            var sigma = BigInteger.ModPow(big, rsa.PrivateKey.D, rsa.PrivateKey.N);
            Console.WriteLine(sigma);
            var output = BigInteger.ModPow(sigma, rsa.PublicKey.E, rsa.PublicKey.N);
            Console.WriteLine(output);
        }
    }

}
