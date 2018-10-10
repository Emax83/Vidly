using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentity(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }

        //gateway to database
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public DbSet<Customer> Customers { get; set; }

            public ApplicationDbContext()
                :base("DbConnection",throwIfV1Schema:false)
            {
                
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }

    }
}