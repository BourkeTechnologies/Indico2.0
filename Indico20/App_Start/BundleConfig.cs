using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

// ReSharper disable once CheckNamespace
namespace Indico20.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/js_dev").Include(
            //    "~/Scripts/jquery-{version}.js",
            //    "~/Scripts/jquery-{version}.intellisense.js",
            //    "~/Scripts/bootstrap.js"
            //));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/jquery-{version}.min.js",
                "~/Scripts/bootstrap.min.js"
            ));

            //bundles.Add(new StyleBundle("~/Content/themes/css_dev").Include(
            //    "~/Content/bootstrap/bootstrap.css",
            //    "~/Content/bootstrap/bootstrap-theme.css"
            //));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap/bootstrap.min.css",
                "~/Content/Styles/Indic20Styles.css"
            ));
        }
    }
}