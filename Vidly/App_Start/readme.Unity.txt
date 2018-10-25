Per utilizzare Unity segui i seguenti passi:

1) Utilizza NugetPacket Manager ed installa Unity by Microsoft e Unity.Mvc5 by Paul Hiles (utilizza il componente base)

2) nel file global.asax aggiungi una riga:
 
public class MvcApplication : System.Web.HttpApplication
{
  protected void Application_Start()
  {
    AreaRegistration.RegisterAllAreas();
    UnityConfig.RegisterComponents();                           // <----- Add this line
    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    RouteConfig.RegisterRoutes(RouteTable.Routes);
    BundleConfig.RegisterBundles(BundleTable.Bundles);
  }           
}  

3) crea le interfacce

4) crea delle classi che implementino le interfacce

5) nel costruttore delle classi chiedi i parametri che ti servono.

6) in unity registra i servizi e passa i parametri al costruttore.

7) per web api utilizzare "UnityResolver.cs e registrare i componenti in WebApiConfig.cs"