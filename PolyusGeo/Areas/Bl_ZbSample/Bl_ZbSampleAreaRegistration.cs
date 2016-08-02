using System.Web.Mvc;
using System.Web.Optimization;

namespace PolyusGeo.Areas.Bl_ZbSample
{
    public class Bl_ZbSampleAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Bl_ZbSample";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Bl_ZbSample",
                "Bl_ZbSample/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                                namespaces: new[] { "PolyusGeo.Areas.Bl_ZbSample.Controllers" }
            );

            BundleTable.Bundles.Add(new Bundle("~/Bl_ZbSample/bundles/scripts").Include(
                        "~/Areas/Bl_ZbSample/Scripts/AutoConnect.js",
                        "~/Areas/Bl_ZbSample/Scripts/btnExecute_onclick.js",
                        "~/Areas/Bl_ZbSample/Scripts/Library.js",
                        "~/Areas/Bl_ZbSample/Scripts/ang_app.js",
                        "~/Areas/Bl_ZbSample/Scripts/Ready.js"
                        ));
            BundleTable.Bundles.Add(new Bundle("~/Bl_ZbSample/bundles/css").Include(
                        "~/Areas/Bl_ZbSample/Content/css.css"
                        ));
        }
    }
}