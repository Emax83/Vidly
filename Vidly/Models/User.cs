using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class User
    {

        public int UserId { get; set; }

        public string UserCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public bool Disabled { get; set; }

        public List<string> Roles { get; set; }
        public List<string> Permissions { get; set; }
        public List<string> Applications { get; set; }


    }
}