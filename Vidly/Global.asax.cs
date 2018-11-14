using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using Vidly.Infrastracture.Authentication;


namespace Vidly
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AjaxHelper.GlobalizationScriptPath = "http://ajax.microsoft.com/ajax/4.0/1/globalization/";
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        
        protected void Application_PostAuthenticateRequest()
        {
            AuthenticationManager.ReadCurrentUser();
        }
    }

    
}
