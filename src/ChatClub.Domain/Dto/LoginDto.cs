﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClub.Domain.Dto
{
    public class LoginDto
    {
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}
