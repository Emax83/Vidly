using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Extensions;
using Vidly.Infrastracture;
using Vidly.Models;
using Vidly.Infrastracture.Authentication;
using System.Web.Mvc.Filters;
using System.Security.Principal;
using System.Web.Routing;
using System.Web.Security;

namespace Vidly
{
    //public class CustomAuthorizeAttribute : AuthorizeAttribute
    //{
    //    //public string Application { get; set; }
    //    //public string[] Roles { get; set; }

    //    public override void OnAuthorization(AuthorizationContext filterContext)
    //    {
    //        if (filterContext == null)
    //        {
    //            throw new ArgumentNullException("filterContext");
    //        }

    //        //if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
    //        //{
    //        //    // auth failed, redirect to login page
    //        //    filterContext.Result = new HttpUnauthorizedResult();
    //        //    return;
    //        //}
                       

    //        string url = filterContext.HttpContext.Request.Url.Query;
    //        if (HttpContext.Current.User is UserPrincipal)
    //        {
    //            UserPrincipal p = ((UserPrincipal)HttpContext.Current.User);
    //            //User user = p.User;
    //            if (!p.IsInRole(Roles))
    //            {
    //                filterContext.Result = new RedirectToRouteResult(
    //                    new System.Web.Routing.RouteValueDictionary(
    //                        new { controller = "Errors", action = "Unauthorized" }));
    //                return;
    //            }
    //        }
    //        //else
    //        //{
    //        //    filterContext.Result = new RedirectToRouteResult(
    //        //    new System.Web.Routing.RouteValueDictionary(
    //        //        new { controller = "Account", action = "Login", ReturnUrl=url }));
    //        //    return;
    //        //}
    //        base.OnAuthorization(filterContext);

    //    }

    //    protected override bool AuthorizeCore(HttpContextBase httpContext)
    //    {
    //        var Isauthorized = base.AuthorizeCore(httpContext);
    //        if (!Isauthorized)
    //            return false;

    //        UserPrincipal user = httpContext.CurrentUser();
    //        if (user != null)
    //        {
    //            return user.IsInRole(base.Roles);
    //        }

    //        return false;

    //    }
    //}

    public class CustomAuthAttribute : AuthorizeAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (!filterContext.Principal.Identity.IsAuthenticated)
                filterContext.Result = new HttpUnauthorizedResult();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext context)
        {
            if (context.Result == null || context.Result is HttpUnauthorizedResult)
            {
                
                context.Result = new RedirectToRouteResult(new RouteValueDictionary {
                {"controller", "Account"},
                {"action", "Login"},
                {"returnUrl", context.HttpContext.Request.RawUrl}
                });
            }
            else
            {
                //check if in role
            }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            string url = filterContext.HttpContext.Request.Url.Query;
            if (HttpContext.Current.User is UserPrincipal)
            {
                UserPrincipal p = ((UserPrincipal)HttpContext.Current.User);
                //User user = p.User;
                if (!p.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(
                            new { controller = "Errors", action = "Unauthorized" }));
                    return;
                }
            }
            base.OnAuthorization(filterContext);

        }
    }
}