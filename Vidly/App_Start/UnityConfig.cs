using CommonServiceLocator;
using System.Web.Mvc;
using System.Configuration;
using Unity;
using Unity.Injection;
using Unity.Mvc5;
using Unity.ServiceLocation;
using Vidly.Infrastracture;
using Vidly.Models;


namespace Vidly
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            //registra qui tutti quei compomente che riutilizza varie volte, come il dbcontext, il dbHelper, logger ecc,
            //tutti i componmenti che ti servono nei controller.
            //crea dei servizi che implementino delle interfacce.
            // nel costruttore dei controller chiedi le interfacce, unity passerà il componente che le implemente.

           
            RegisterRepositoryServices(container);

            // e.g. container.RegisterType<ITestService, TestService>();

            ServiceLocator.SetLocatorProvider(()=>new UnityServiceLocator(container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void RegisterRepositoryServices(UnityContainer container)
        {

            string connectionstring = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            ApplicationDbContext dbContext = new ApplicationDbContext();
            //DBHelper dBHelper = new DBHelper(connectionstring);

            container.RegisterType<IMovieService, EFMovieService>(new InjectionConstructor(dbContext));
            container.RegisterType<ICustomerService, EFCustomerService>(new InjectionConstructor(dbContext));
            //container.RegisterType<IMovieService, DBMovieService>(new InjectionConstructor(dBHelper));

        }
    }
}