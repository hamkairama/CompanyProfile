using System.Web;
using System.Web.Optimization;

namespace CompanyProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //cutom js
            bundles.Add(new ScriptBundle("~/bundles/custom/js").Include(
                    "~/Custom/vendor/jquery/jquery.min.js",
                    "~/Custom/vendor/bootstrap/js/bootstrap.bundle.min.js",
                    "~/Custom/vendor/jquery-easing/jquery.easing.min.js",
                    "~/Custom/js/jqBootstrapValidation.js",
                    "~/Custom/js/contact_me.js",
                    "~/Custom/js/agency.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom/css").Include(
                  "~/Custom/vendor/bootstrap/css/bootstrap.min.css",
                  "~/Custom/vendor/font-awesome/css/font-awesome.min.css",
                  "~/Custom/css/agency.min.css"));
        }
    }
}
