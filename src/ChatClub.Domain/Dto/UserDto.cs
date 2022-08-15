using System.ComponentModel.DataAnnotations;

namespace ChatClub.Domain.Dto
{
    public class UserDto
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
