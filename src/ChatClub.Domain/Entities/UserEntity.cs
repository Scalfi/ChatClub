
using System.ComponentModel.DataAnnotations.Schema;


namespace ChatClub.Domain.Entities
{
    [Table("users")]
    public class UserEntity : BaseEntity
    {
        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
