using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Extensions
{
    public static class CurrentUserExtension
    {
        public static void CurrentUser(this System.Web.HttpContext context)
        {
            if (context.User == null || context.User)
                return null;


            return context.User;
        }
    }
}