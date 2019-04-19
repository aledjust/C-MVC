using System.Web.Optimization;

namespace ArtistsCRUD
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/datatables.min.js")
                .Include("~/Scripts/moment.min.js")
                .Include("~/Scripts/datetime-moment.js")
                .Include("~/Scripts/dataTables.select.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include( "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css","~/Content/site.css")
                .Include("~/Content/datatables.min.css")
                .Include("~/Content/select.dataTables.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/albumsartists")
                .Include("~/Scripts/Artists.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
