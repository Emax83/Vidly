using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool IsSuperAdmin { get; set; }
    }

    public class Roles
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string Admin = "Admin";
        public const string User = "User";
    }

}