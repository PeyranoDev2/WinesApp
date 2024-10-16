﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class UserForCreateDTO
    {
        public string Username { get; set; }

        [MinLength(12)]
        public string Password { get; set; }
    }
}