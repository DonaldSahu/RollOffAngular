using System;
using System.Collections.Generic;

#nullable disable

namespace RollOffBackend.Models
{
    public partial class LoginTable
    {
        public int Userid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }
        public string Password { get; set; }
    }
}
