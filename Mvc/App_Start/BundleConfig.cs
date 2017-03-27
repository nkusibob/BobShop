using System.Web;
using System.Web.Optimization;

namespace Mvc
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            bundles.Add(new StyleBundle("~/bundles/adminSharedCss").Include(
                "~/assets/plugins/bootstrap/css/bootstrap.min.css",
                "~/assets/css/font-awesome.min.css",
                "~/assets/css/animate.css",
                "~/assets/plugins/jvectormap/css/jquery-jvectormap-1.2.2.css",
                "~/assets/css/main.css",
                "~/assets/plugins/todo/css/todos.css",
                "~/assets/plugins/morris/css/morris.css",
                "~/assets/plugins/jvectormap/css/jquery-jvectormap-1.2.2.css",
                "~/assets/plugins/todo/css/todos.css",
                "~/assets/plugins/morris/css/morris.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/adminSharedJs").Include(
              "~/Scripts/js/jquery.js",
             "~/assets/js/modernizr-2.6.2.min.js"

                ));
            bundles.Add(new ScriptBundle("~/bundles/adminSharedGlobalJs").Include(
            "~/assets/js/jquery-1.10.2.min.js",
            "~/assets/plugins/bootstrap/js/bootstrap.min.js",
            "~/assets/plugins/waypoints/waypoints.min.js",
            "~/assets/js/application.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/adminSharedPageLevelJs").Include(
                "~/assets/plugins/countTo/jquery.countTo.js",
                "~/assets/plugins/weather/js/skycons.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                        "~/Scripts/js/jquery.js",
                        "~/Scripts/js/bootstrap.js",
                        "~/Scripts/plugins/waypoints.js",
                        "~/Scripts/plugins/jquery.nanoscroller.js",
                        "~/Scripts/js/application.js",
                        "~/Scripts/plugins/jquery.dataTables.js",
                        "~/Scripts/plugins/dataTables.bootstrap.js",
                        "~/Scripts/js/bootstrap.touchspin.js",
                        "~/Scripts/js/jquery.bxslider.js",
                        "~/Scripts/js/jquery.blImageCenter.js",
                        "~/Scripts/js/smoothproducts.js"));
                       

            bundles.Add(new StyleBundle("~/Content/frontend/bootstrapcss").Include(
                        "~/Content/frontend/css/bootstrap.css",
                        "~/Content/frontend/css/bootstrap-override.css",
                        "~/Content/frontend/css/font-awesome.css",
                        "~/css/demo.css",
                         "~/css/style.css",
                        "~/Content/frontend/css/jquery.bxslider.css",
                        "~/Content/frontend/css/smoothproducts.css",
                        "~/Content/frontend/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/backend/bootstrapcss").Include(
            "~/Content/frontend/css/bootstrap.css",
                "~/Content/backend/css/animate.css",
            "~/Content/backend/css/font-awesome.css",
            "~/Content/backend/css/main.css",
            "~/Content/backend/css/dataTables.css"));

        }
    }
}