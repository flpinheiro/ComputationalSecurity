using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var rsa = Generator.GenRSA();
            Console.WriteLine(rsa);
        }
    }

}
