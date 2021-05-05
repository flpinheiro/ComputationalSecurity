using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var rsa = Generator.GenRSA();
            Console.WriteLine(rsa);
            Signer.Sign(rsa.PrivateKey, "bela noite de verão");
        }
    }

}
