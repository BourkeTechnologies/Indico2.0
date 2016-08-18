using System.Web.Optimization;

namespace Indico20
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/kendo.compatibility.css",
                "~/Content/kendo/2016.2.714/kendo.common-bootstrap.min.css",
                "~/Content/kendo/2016.2.714/kendo.mobile.all.min.css",
                "~/Content/kendo/2016.2.714/kendo.dataviz.min.css",
                "~/Content/kendo/2016.2.714/kendo.bootstrap.min.css",
                "~/Content/kendo/2016.2.714/kendo.dataviz.bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/kendo/2016.2.714/jquery.min.js",
                "~/Scripts/kendo/2016.2.714/jszip.min.js",
                "~/Scripts/kendo/2016.2.714/kendo.all.min.js",
                "~/Scripts/kendo/2016.2.714/kendo.aspnetmvc.min.js",
                "~/Scripts/kendo.modernizr.custom.js",
                "~/Scripts/bootstrap.min.js"
                ));

            bundles.IgnoreList.Clear();
        }
    }
}
