using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClub.Domain.Entities
{
    public class LoginEntity : BaseEntity
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
