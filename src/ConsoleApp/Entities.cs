using System.Numerics;

namespace ConsoleApp
{
    public record PrivateKey(BigInteger N, BigInteger D);

    public record PublicKey(BigInteger N, BigInteger E);

    public record RSA(PrivateKey Pk, PublicKey Sk, BigInteger P, BigInteger Q);
}
