﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeChecker.Domain.Models
{
    public class User : DomainObject
    {

        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}