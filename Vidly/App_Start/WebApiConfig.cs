using Newtonsoft.Json.Serialization;
using System.Web.Http;
using Unity;
using Vidly.Infrastracture;
using Vidly.Repository;

namespace Vidly
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            /* to camelcase json result: using Newtonsoft.Json.Serialization; */
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;

            ApplicationDbContext dbContext = new ApplicationDbContext();
            //DBHelper dBHelper = new DBHelper(connectionstring);

            /* DEPENDENCY INJECTION PER WEB API */
            var container = new UnityContainer();
            container.RegisterType<ICustomerService, EFCustomerService>();
            container.RegisterType<IMovieService, EFMovieService>();
            container.RegisterType<IUserService, EFUserService>();
            //container.RegisterType<IRentalService, EFRentalService>();

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
