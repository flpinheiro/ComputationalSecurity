using System.ComponentModel.DataAnnotations;
using System.Numerics;
using UnB.Security.Domain;

namespace UnB.Security.WebApi.Dto
{
    public class RSAMessageDto
    {
        [Required]
        public string Message { get; set; }
        [Required]
        public string Sigma { get; set; }
        [Required]
        public PublicKeyDto PublicKey { get; set; }

        internal RSAMessage ToRSAMessage()
        {
            var sigma = BigInteger.Parse(Sigma);
            return new RSAMessage(Message, sigma);
        }
    }
}
