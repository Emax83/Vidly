using Vidly.Infrastracture;
using Vidly.Models;

namespace Vidly
{
    public static class HttpContextExtensions
    {
        public static UserPrincipal CurrentUser(this System.Web.HttpContextBase context)
        {
            if (context.User is UserPrincipal)
                return (UserPrincipal)context.User;

            return null;
        }
    }
}