using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppJwt.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Groups { get; set; }
        public string Organization { get; set; }
    }
}
