using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Vidly.Models
{
    public class User //: IdentityUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public bool Disabled { get; set; }

        public List<UserRole> UserRoles { get; set; }

        

    }
}