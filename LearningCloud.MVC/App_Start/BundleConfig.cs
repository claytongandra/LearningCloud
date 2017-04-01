using System.Web;
using System.Web.Optimization;

namespace LearningCloud.MVC
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

            bundles.Add(new ScriptBundle("~/bundles/javascript/Varsity/Index").Include(
                        "~/Scripts/Plugins/slick.js",    
                        "~/Scripts/Plugins/waypoints.js",
                        "~/Scripts/Plugins/jquery.counterup.js",
                        "~/Scripts/Varsity/custom.js",
                        "~/Scripts/default.Varsity.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/javascript/AdminLTE").Include(
                        "~/Scripts/Plugins/jquery.slimscroll.min.js",
                        "~/Scripts/Plugins/fastclick.min.js",
                        "~/Scripts/AdminLTE/app.js",
                        "~/Scripts/Plugins/jquery.fileuploader.min.js",
                        "~/Scripts/Plugins/ckeditor/ckeditor.js",
                        "~/Scripts/Plugins/ckeditor/config.js",
                        "~/Scripts/default.AdminLTE.js"
                      ));


            bundles.Add(new StyleBundle("~/Content/css/Varsity").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/Plugins/slick.css",
                      "~/Content/Templates/Varsity/Theme-color/green-theme.css",
                      "~/Content/Templates/Varsity/Varsity.css",
                      "~/Content/Site.Varsity.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/css/AdminLTE").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                        "~/Content/Plugins/ckeditor/ckeditor.contents.css",
                      "~/Content/Templates/AdminLTE/AdminLTE.css",
                      "~/Content/Templates/AdminLTE/Skins/skin-green.min.css",
                      "~/Content/Plugins/jquery.fileuploader.css",
                      "~/Content/Site.AdminLTE.css"));

            BundleTable.EnableOptimizations = false;

        }
    }
}
