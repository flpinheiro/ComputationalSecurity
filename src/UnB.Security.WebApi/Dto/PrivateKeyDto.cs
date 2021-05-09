using System.ComponentModel.DataAnnotations;
using System.Numerics;
using UnB.Security.Domain;

namespace UnB.Security.WebApi.Dto
{
    public class PrivateKeyDto
    {
        [Required]
        public string N { get; set; }

        [Required]
        public string D { get; set; }

        public PrivateKeyDto()
        {

        }

        public PrivateKeyDto(string n, string d)
        {
            N = n;
            D = d;
        }

        public PrivateKeyDto(PrivateKey privateKey)
        {
            N = privateKey.N.ToString();
            D = privateKey.D.ToString();
        }

        public PrivateKey ToPrivateKey()
        {
            var n = BigInteger.Parse(N);
            var d = BigInteger.Parse(D);
            return new PrivateKey(n, d);
        }
    }
}
