using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var rsa = RSAFuncitions.GenRSA();
            Console.WriteLine(rsa);
        }
    }

}
