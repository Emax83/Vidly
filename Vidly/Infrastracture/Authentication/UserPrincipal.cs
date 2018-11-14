using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Vidly.Models;

namespace Vidly.Infrastracture
{
    public class UserPrincipal : IPrincipal
    {
        public User User {get;set;}
        public List<string> Roles
        {
            get
            {
                return this.User.UserRoles.Select(r => r.Name.ToUpper()).ToList();
            }
        }

        public UserPrincipal(User user)
        {
            this.User = user;// _service.FindByMail(email);
            Identity = new GenericIdentity(this.User.FullName, "Forms") { Label = user.FullName};
        }

        public IIdentity Identity
        {
            get; private set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(',');
            return roles.Any(r => this.Roles.Contains(r.ToUpper()));
        }

        //public bool HasPermission(string permission)
        //{
        //    var permissions = permission.Split(',');
        //    return permissions.Any(p => this.Permissions.Contains(p));
        //}

        //public bool HasAccess(string application)
        //{
        //    if (Applications.Any(r => application.ToUpper().Contains(r.ToUpper())))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public bool IsLogged()
        {
            return !( User == null);
        }
    }
}