using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Vidly.Infrastracture;

namespace Vidly
{
    public static class HtmlHelpers
    {
        //public static bool HasPermission(this HtmlHelper helper,string permission)
        //{
        //    if (HttpContext.Current.User is UserPrincipal)
        //    {
        //        UserPrincipal user = (UserPrincipal)HttpContext.Current.User;
        //        return user.HasPermission(permission);
        //    }
        //    return false;
        //}

        public static UserPrincipal CurrentUser(this HtmlHelper html)
        {
            if (HttpContext.Current.User is UserPrincipal)
                return (UserPrincipal)HttpContext.Current.User;
            
            return null;
        }

        public static MvcHtmlString AntiforgeryTokenAjax(this HtmlHelper html)
        {
            string token = "";
            string tag = html.AntiForgeryToken().ToString();
            token = string.Format(@"{0}:""{1}""","__RequestVerificationToken", token);
            return new MvcHtmlString(token);
        }

    }
}