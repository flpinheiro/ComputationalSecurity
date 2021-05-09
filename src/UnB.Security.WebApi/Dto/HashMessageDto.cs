using System.ComponentModel.DataAnnotations;
using UnB.Security.Domain;

namespace UnB.Security.WebApi.Dto
{
    public class HashMessageDto
    {
        [Required]
        public string Message { get; set; }
        [Required]
        public string Sigma { get; set; }

        public HashMessageDto(RSAMessage hash)
        {
            Message = hash.Message;
            Sigma = hash.Sigma.ToString();
        }
    }
}
