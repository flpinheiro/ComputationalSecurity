using System.ComponentModel.DataAnnotations;
using System.Numerics;
using UnB.Security.Domain;

namespace UnB.Security.WebApi.Dto
{
    public class PublicKeyDto
    {
        [Required]
        public string N { get; set; }
        [Required]
        public string E { get; set; }
        public PublicKeyDto() { }

        public PublicKeyDto(string n, string e):this()
        {
            N = n;
            E = e;
        }

        public PublicKeyDto(PublicKey publicKey)
        {
            N = publicKey.N.ToString();
            E = publicKey.E.ToString();
        }

        public PublicKey ToPublicKey()
        {
            var n = BigInteger.Parse(N);
            var e = BigInteger.Parse(E);
            return new PublicKey(n, e);
        }
    }
}
