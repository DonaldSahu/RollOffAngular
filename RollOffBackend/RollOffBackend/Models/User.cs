﻿using System;
using System.Collections.Generic;

#nullable disable

namespace RollOffBackend.Models
{
    public partial class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
    }
}
