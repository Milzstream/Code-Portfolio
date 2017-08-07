using System.Web;
using System.Web.Optimization;

namespace NoGuardianLeftBehind
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

    // ------------------------------> JavaScript Librarys <---------------------------------- //

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Librarys/jquery/jquery-{version}.js",
                        "~/Scripts/Librarys/jquery/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/notify").Include(
                      "~/Scripts/Librarys/jquery/jquery.noty.packaged.js",
                      "~/Scripts/Librarys/jquery/jquery.noty.relax.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/signalR").Include(
                      "~/Scripts/Librarys/jquery/jquery.signalR-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/browseralert").Include(
                      "~/Scripts/Librarys/jquery/jquery.titlealert.js"));

            bundles.Add(new ScriptBundle("~/bundles/carousel").Include(
                      "~/Scripts/Librarys/owl-carousel/owl.carousel.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Librarys/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Librarys/bootstrap/bootstrap.js",
                      "~/Scripts/Librarys/bootstrap/respond.js"));
                      //"~/Scripts/Librarys/bootstrap/bootcards.js"));

            bundles.Add(new ScriptBundle("~/bundles/formvalidation").Include(
                      "~/Scripts/Librarys/formvalidation/formValidation.js",
                      "~/Scripts/Librarys/formvalidation/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/livicons").Include(
                      "~/Scripts/Librarys/livicons/raphael.js",
                      "~/Scripts/Librarys/livicons/livicons-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/holder").Include(
                      "~/Scripts/Librarys/holder/holder.js"));


    // ------------------------------> Custom/Page JS <---------------------------------- //

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                      "~/Scripts/Pages/common.js",
                      "~/Scripts/Pages/frontend.js"));

            bundles.Add(new ScriptBundle("~/bundles/404").Include(
                      "~/Scripts/Pages/Error/404.js"));

            bundles.Add(new ScriptBundle("~/bundles/home-carousel").Include(
                      "~/Scripts/Pages/Home/carousel.js"));

            bundles.Add(new ScriptBundle("~/bundles/contact").Include(
                      "~/Scripts/Pages/About/contact.js"));


    // ------------------------------> Library Styles CSS <---------------------------------- //

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/Librarys/bootstrap/bootstrap.css"));

           bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                      "~/Content/Librarys/font-awesome/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/formvalidation").Include(
                      "~/Content/Librarys/formvalidation/formValidation.css"));

            bundles.Add(new StyleBundle("~/Content/animate").Include(
                      "~/Content/Librarys/animate/animate.css"));

            bundles.Add(new StyleBundle("~/Content/tabbular").Include(
                      "~/Content/Librarys/tabbular/tabbular.css"));

            bundles.Add(new StyleBundle("~/Content/carousel").Include(
                      "~/Content/Librarys/owl-carousel/owl.carousel.css",
                      "~/Content/Librarys/owl-carousel/owl.theme.css"));

   // ------------------------------> Custom/Page Styles CSS <---------------------------------- //

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Pages/site.css",
                      "~/Content/Pages/custom.css"));

            bundles.Add(new StyleBundle("~/Content/404").Include(
                      "~/Content/Pages/Error/404.css"));

            bundles.Add(new StyleBundle("~/Content/500").Include(
                      "~/Content/Pages/Error/500.css"));

 
        }
    }
}
