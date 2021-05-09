using System.ComponentModel.DataAnnotations;
using UnB.Security.Domain;

namespace UnB.Security.WebApi.Dto
{
    public class MessageDto
    {
        [Required]
        public string Message { get; set; }

        [Required]
        public PrivateKeyDto PrivateKey { get; set; }
    }
}
