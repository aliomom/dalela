using System.Web;
using System.Web.Optimization;

namespace NawafizApp.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     // "~/Content/JQuery/demo.js",
                     //  "~/Content/JQuery/demo.min.js",
                     // "~/Content/JQuery/layout.js",
                     //"~/Content/JQuery/layout.min.js",
                    // "~/Content/JQuery/jquery.min.js",
                     "~/Scripts/jquery-3.1.1.js",
                     // "~/Content/JQuery/V_jquery.min.js",
                     "~/Content/JQuery/jquery.prettyPhoto.js",
                   //  "~/Content/JS/jquery.treegrid.js",
                        "~/Scripts/jquery.validate.js"
                        //   "~/Content/JQuery/Layouts_Global/quick-nav.min.js", "~/Content/JQuery/Layouts_Global/quick-sidebar.min.js",
                        //"~/Scripts/jquery-{version}.js"

                        ));// 
            bundles.Add(new ScriptBundle("~/bundles/V_jquery").Include(
                       // "~/Content/JQuery/demo.js",
                     //  "~/Content/JQuery/demo.min.js",
                   // "~/Content/JQuery/layout.js",
                   //"~/Content/JQuery/layout.min.js",
                   //"~/Content/JQuery/jquery.min.js",
                   //  "~/Scripts/jquery-3.1.1.js",
                   //"~/Content/JQuery/V_jquery.min.js",
                   //"~/Content/JQuery/jquery.prettyPhoto.js",
                  //    "~/Scripts/jquery.validate.js"
                       // "~/Content/JQuery/Layouts_Global/quick-nav.min.js", "~/Content/JQuery/Layouts_Global/quick-sidebar.min.js"
                     //    "~/Scripts/jquery-{version}.js"    
                       ));// 



            bundles.Add(new ScriptBundle("~/bundles/javascript").Include(
                                                                         "~/Content/JS/app.min.js",
                                                                         "~/Cotent/JS/layout.min.js"

                ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/app.min.js",
                                             "~/Content/JQuery/Global/quick-nav.min.js",
                                             "~/Scripts/layout.min.js",

                     "~/Scripts/dashboard.min.js",
                     "~/Scripts/respond.js"
                      ));/////////////////


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/layout-rtl.min.css",
                 "~/Content/components-rtl.min.css",
                 "~/Content/bootstrap.css",
                      "~/Content/simple-line-icons/simple-line-icons.min.css",
                      "~/Content/darkblue-rtl.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/custom-rtl.min.css",
                      "~/Content/category_view/Css/AdminCategory1.css",
                      "~/Content/_sidebar.scss",
                      "~/Content/bootstrap-switch-rtl.min.css",
                      //"~/Content/site.css",
                          "~/Content/bootstrap-rtl.min.css"

                      ));  //  , 
        }
    }
}
