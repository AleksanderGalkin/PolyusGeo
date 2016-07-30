using System.Web.Mvc;
using System.Web.Optimization;

namespace PolyusGeo.Areas.Bl_DhSample
{
    public class Bl_DhSampleAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Bl_DhSample";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Bl_DhSample_default",
                "Bl_DhSample/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                                namespaces: new[] { "PolyusGeo.Areas.Bl_DhSample.Controllers" }
            );

            BundleTable.Bundles.Add(new Bundle("~/Bl_DhSample/bundles/scripts").Include(
                        "~/Areas/Bl_DhSample/Scripts/AutoConnect.js",
                        "~/Areas/Bl_DhSample/Scripts/btnExecute_onclick.js",
                        "~/Areas/Bl_DhSample/Scripts/Library.js",
                        "~/Areas/Bl_DhSample/Scripts/ang_app.js",
                        "~/Areas/Bl_DhSample/Scripts/Ready.js"
                        ));
            BundleTable.Bundles.Add(new Bundle("~/Bl_DhSample/bundles/css").Include(
                        "~/Areas/Bl_DhSample/Content/css.css"
                        ));
        }
    }
}