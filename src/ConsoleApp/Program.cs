using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;

namespace ConsoleApp
{
    class Program
    {
        /// <summary>
        /// Returna um número inteiro positivo impar. 
        /// </summary>
        /// <param name="size">Tamanho em bits do numero a ser retornado, deve ser maior do que 3, ou retornará 0 ou 1 padrão = 1024, recomendado maior que 64</param>
        /// <returns>Inteiro positivo impar</returns>
        private static BigInteger GetRandomBigInteger(int size)
        {
            if (size < 1) return 0;
            byte[] randBit = new byte[size];
            RandomNumberGenerator.Create().GetBytes(randBit);
            randBit[0] = 1; // valor impar
            return BigInteger.Abs(new BigInteger(randBit));
        }

        /// <summary>
        /// verfica se o número é primo
        /// </summary>
        /// <param name="number">numero a ser verifica se é primo</param>
        /// <returns>true se o número for primo e false se não for.</returns>
        private static bool IsPrime(BigInteger number)
        {
            //verfica a lista dos primeiro primos conhecidos.
            List<BigInteger> primeList = new()
            {
                2,
                3,
                5,
                7,
                11,
                13,
                17,
                19,
                23,
                29,
                31,
                37,
                41,
                43,
                47,
                53,
                59,
                61,
                67,
                71,
                73,
                79,
                83,
                89,
                97,
                101,
                103,
                107,
                109,
                113,
                127,
                131,
                137,
                139,
                149,
                151,
                157,
                163,
                167,
                173,
                179,
                181,
                191,
                193,
                197,
                199,
                211,
                223,
                227,
                229,
                233,
                239,
                241,
                251,
                257,
                263,
                269,
                271,
                277,
                281,
                283,
                293,
                307,
                311,
                313,
                317,
                331,
                337,
                347,
                349
            };
            if (primeList.Any(p => number % p == 0 && p != number)) return false;
            return true;
        }

        /// <summary>
        /// Miller-Rabin primality test as an extension method on the BigInteger type.
        /// </summary>
        /// <param name="source">numero a ser verificado se é primo</param>
        /// <param name="certainty"></param>
        /// <returns>retorna true se o número é provavelmente primo e false se ele ñão é primo.</returns>
        public static bool IsProbablePrime(BigInteger source, int certainty = 20)
        {
            if (source == 2 || source == 3)
                return true;
            if (source < 2 || source % 2 == 0)
                return false;
            if (IsPrime(source))
                return true;

            BigInteger d = source - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            // There is no built-in method for generating random BigInteger values.
            // Instead, random BigIntegers are constructed from randomly generated
            // byte arrays of the same length as the source.
            BigInteger a;

            for (int i = 0; i < certainty; i++)
            {
                do
                {
                    // This may raise an exception in Mono 2.10.8 and earlier.
                    // http://bugzilla.xamarin.com/show_bug.cgi?id=2761
                    a = GetRandomBigInteger(source.ToByteArray().Length);
                }
                while (a < 2 || a >= source - 2);

                BigInteger x = BigInteger.ModPow(a, d, source);
                if (x == 1 || x == source - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, source);
                    if (x == 1)
                        return false;
                    if (x == source - 1)
                        break;
                }

                if (x != source - 1)
                    return false;
            }

            return true;
        }


        /// <summary>
        /// Returna um número primo para ser usado como chave de criptografia.
        /// </summary>
        /// <param name="bitSize">tamanho da chave em bit, padrão 1024</param>
        /// <returns>Retorna um número primo para ser usado como chave de criptográfia</returns>
        private static BigInteger GetKey(int size = 1024)
        {
            BigInteger key;
            do
            {
                key = GetRandomBigInteger(size);
            } while (IsProbablePrime(key));
            return key;
        }

        static void Main()
        {

            var p = GetKey();
            var q = GetKey();
            var e = GetKey(32);
            Console.WriteLine($"p = {p}, tamanho = {p.ToByteArray().Length * 8}");
            Console.WriteLine($"q = {q}, tamanho = {q.ToByteArray().Length * 8}");
            Console.WriteLine($"e = {e}, tamanho = {e.ToByteArray().Length * 8}");
            var n = p * q;
            var phi = (p - 1) * (q - 1);
            Console.WriteLine($"n = {n}, tamanho = {n.ToByteArray().Length * 8}");
            Console.WriteLine($"phi = {phi}, tamanho = {phi.ToByteArray().Length * 8}");

            var key = (n, e);

        }
    }
}
