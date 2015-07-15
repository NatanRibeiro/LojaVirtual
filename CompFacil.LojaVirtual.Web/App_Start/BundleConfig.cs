using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Collections.Generic;

namespace CompFacil.LojaVirtual.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Bundles/jquery").Include(
                "~/Scripts/jquery-1.*"));

            bundles.Add(new ScriptBundle("~/Bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-Theme.css",
                "~/Content/ErroEstilo.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}