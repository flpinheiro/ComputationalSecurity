using Microsoft.AspNetCore.Mvc;
using UnB.Security.Services;
using UnB.Security.WebApi.Dto;

namespace UnB.Security.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var rsa = Generator.GenRSA();
            return Ok(new RsaDto(rsa));
        }

        [HttpPost("sign")]
        public IActionResult Sign(MessageDto dto)
        {
            var hashRSA = Signer.Sign(dto.PrivateKey.ToPrivateKey(), dto.Message);
            return Ok(new HashMessageDto(hashRSA));
        }

        [HttpPost("vrfy")]
        public bool Vrfy([FromBody] RSAMessageDto dto)
        {
            var message = dto.ToRSAMessage();
            var publicKey = dto.PublicKey.ToPublicKey();

            return Checker.Vrfy(publicKey, message);
        }

    }
}
