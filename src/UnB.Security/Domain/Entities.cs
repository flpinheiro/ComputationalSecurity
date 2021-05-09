using System.Numerics;

namespace UnB.Security.Domain
{
    public record PrivateKey(BigInteger N, BigInteger D);

    public record PublicKey(BigInteger N, BigInteger E);

    public record RSA(PrivateKey PrivateKey, PublicKey PublicKey);

    public record RSAMessage(string Message, BigInteger Sigma);
}
