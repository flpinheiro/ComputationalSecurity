using UnB.Security.Domain;

namespace UnB.Security.WebApi.Dto
{
    public class RsaDto
    {
        public PublicKeyDto PublicKey { get; set; }
        public PrivateKeyDto PrivateKey { get; set; }

        public RsaDto(RSA rsa)
        {
            PublicKey = new PublicKeyDto(rsa.PublicKey);
            PrivateKey = new PrivateKeyDto(rsa.PrivateKey);
        }
    }
}
