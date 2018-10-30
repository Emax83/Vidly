using System.Web;
using System.Web.Mvc;
using Vidly.Filters;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //qui si registrano i filtri da usare globalmente, in modo da non aggiungere ad ogni controller l'attrbuto
            filters.Add(new HandleErrorAttribute());

            //filters.Add(new AuthorizeAttribute());
            //filters.Add(new ApplicationFilter());
        }
    }
}
