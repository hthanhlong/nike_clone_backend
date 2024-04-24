using System.ComponentModel.DataAnnotations;

namespace Reformation.Dtos.AuthDtos
{
    public class RefreshTokenDto
    {
        [Required]
        public required string RefreshToken { get; set; }
    }
}