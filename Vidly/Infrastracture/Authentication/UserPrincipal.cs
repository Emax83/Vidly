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
        public Customer Customer { get; set; }
        public string[] Roles { get; set; }
        public string[] Applications { get; set; }
        public string[] Permissions { get; set; }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //to login with external providers
        public string Guid { get; set; }

        public UserPrincipal(string name)
        {
            Identity = new GenericIdentity(name);
        }

        public IIdentity Identity
        {
            get; private set;
        }

        public bool IsInRole(string role)
        {
            if (Roles.Any(r => role.ToUpper().Contains(r.ToUpper())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasPermission(string permission)
        {
            if (Permissions.Any(r => permission.ToUpper().Contains(r.ToUpper())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanAccess(string application)
        {
            if (Applications.Any(r => application.ToUpper().Contains(r.ToUpper())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsLogged()
        {
            return !(Customer == null);
        }
    }
}