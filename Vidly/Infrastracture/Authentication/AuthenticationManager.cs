using Vidly.ViewModels;
using Vidly.Infrastracture.Authentication;
using System.Web.Security;
using Vidly.Models;
using System;
using System.Web;
using Vidly.Repository;

namespace Vidly.Infrastracture.Authentication
{
    //https://stackoverflow.com/questions/1064271/asp-net-mvc-set-custom-iidentity-or-iprincipal
    public class AuthenticationManager
    {
        public static string authCookieName = FormsAuthentication.FormsCookieName;

        public static void Logon(User user, bool rememberMe)
        {
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.FullName, rememberMe);
                DateTime expiration;
                if (rememberMe)
                {
                    expiration = DateTime.Now.Date.AddDays(30);
                }
                else
                {
                    expiration = DateTime.Now.Date.AddMinutes(15);
                }


                string userData = Newtonsoft.Json.JsonConvert.SerializeObject(user);

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                    (1, user.FullName, DateTime.Now, expiration, rememberMe, userData);
                string encTicket = FormsAuthentication.Encrypt(authTicket);
                //HttpCookie faCookie = new HttpCookie(authCookieName, encTicket);
                HttpCookie faCookie = FormsAuthentication.GetAuthCookie(user.Email,rememberMe);
                faCookie.Value = encTicket;
                faCookie.Expires = expiration;
                              
                HttpContext.Current.Response.Cookies.Add(faCookie);

                if (HttpContext.Current.Session != null)
                {
                    HttpContext.Current.Session["CurrentUser"] = user;
                }

                SetPrincipal(user);

            }
            else
            {
                Logoff();
            }
        }

        public static void Logoff()
        {
            FormsAuthentication.SignOut();

            HttpCookie cookie = new HttpCookie(authCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
            HttpContext.Current.User = null;
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["CurrentUser"] = null;
            }
        }

        public static void ReadCurrentUser()
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["CurrentUser"] != null)
            {
                var user = ((User)HttpContext.Current.Session["CurrentUser"]);
                Logon(user, true);
                return;
            }

            HttpCookie cookie = HttpContext.Current.Request.Cookies[authCookieName];
            if (cookie != null)
            {
                try
                {
                    string encTicket = cookie.Value;
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(encTicket);
                    string encData = ticket.UserData;
                    User user = ((User)Newtonsoft.Json.JsonConvert.DeserializeObject<User>(encData));
                    if (user!=null)
                        SetPrincipal(user);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

            }
        }

        private static void SetPrincipal(User user) {
            try
            {
                //System.Security.Principal.GenericIdentity identity = new System.Security.Principal.GenericIdentity(user.FullName, "Forms");
                //identity.Label = user.FullName;
                //System.Security.Principal.GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(identity, user.Roles.ToArray());

                //HttpContext.Current.User = principal;
                HttpContext.Current.User = new UserPrincipal(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

    }
}