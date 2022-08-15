using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClub.Domain.Entities
{
    [Table("messages")]
    public class MessageEntity : BaseEntity
    {
        public int UserId { get; set; }

        public LoginEntity? User { get; set; }
        public string? Message { get; set; }
    }
}
