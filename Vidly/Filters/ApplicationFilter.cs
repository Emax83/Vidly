using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Extensions;
using Vidly.Infrastracture;

namespace Vidly.Filters
{
    public class ApplicationFilter : AuthorizeAttribute
    {
        public string Application { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var Isauthorized = base.AuthorizeCore(httpContext);
            if (!Isauthorized)
                return false;

            UserPrincipal user = httpContext.CurrentUser();
            if (user != null)
            {
                return user.CanAccess(this.Application);
            }

            return false;
            
        }
    }
}