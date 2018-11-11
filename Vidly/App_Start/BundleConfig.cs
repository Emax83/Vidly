using System.Web;
using System.Web.Optimization;

namespace Vidly
{
    public class BundleConfig
    {
        // Per altre informazioni sulla creazione di bundle, vedere https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/dataTables.bootstrap.js",
                        "~/Scripts/typeahead.bundle.js",
                        "~/Scripts/toastr.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"
                        //"~/Scripts/jquery.validate.js",
                        //"~/Scripts/jquery.validate.unobtrusive.js"
                        ));

            //http://www.aspitalia.com/script/1218/Impostare-Culture-Client-Side-Validation-ASP.NET-MVC.aspx
            //bundles.Add(new ScriptBundle("~/bundles/globalize").Include(
            //            "~/Scripts/cldr.js",
            //            "~/Scripts/cldr/event.js",
            //            "~/Scripts/cldr/supplemental.js",
            //            "~/Scripts/globalize.js",
            //            "~/Scripts/globalize/number.js",
            //            "~/Scripts/globalize/date.js"
            //            ));


            // Utilizzare la versione di sviluppo di Modernizr per eseguire attività di sviluppo e formazione. Successivamente, quando si è
            // pronti per passare alla produzione, usare lo strumento di compilazione disponibile all'indirizzo https://modernizr.com per selezionare solo i test necessari.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-grid.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/font-awesome.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/DataTables/css/jquery.dataTables.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/typeahead.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));

            //using CDN
            //bundles.UseCdn = true;   //ena
            //var jqueryCdnPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.1.min.js";
            //bundles.Add(new ScriptBundle("~/bundles/jquery",
            //            jqueryCdnPath).Include(
            //            "~/Scripts/jquery-{version}.js"));


            BundleTable.EnableOptimizations = true;

        }
    }
}
