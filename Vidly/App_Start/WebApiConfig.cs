using System.Web.Http;
using Unity;
using Unity.Injection;
using Vidly.Infrastracture;
using Vidly.Repository;

namespace Vidly
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            //DBHelper dBHelper = new DBHelper(connectionstring);

            /* DEPENDENCY INJECTION PER WEB API */
            var container = new UnityContainer();
            container.RegisterType<ICustomerService, EFCustomerService>();
            //container.RegisterType<ICustomerService, EFCustomerService>(new InjectionConstructor(dbContext));

            config.DependencyResolver = new UnityResolver(container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
