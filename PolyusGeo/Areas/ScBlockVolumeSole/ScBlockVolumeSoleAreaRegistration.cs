using System.Web.Mvc;
using System.Web.Optimization;

namespace PolyusGeo.Areas.ScBlockVolumeSole
{
    public class ScBlockVolumeSoleAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ScBlockVolumeSole";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ScBlockVolumeSole_default",
                "ScBlockVolumeSole/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                                namespaces: new[] { "PolyusGeo.Areas.ScBlockVolumeSole.Controllers" }
            );

            BundleTable.Bundles.Add(new Bundle("~/ScBlockVolumeSole/bundles/scripts").Include(
                    "~/Areas/ScBlockVolumeSole/Scripts/AutoConnect.js",
                    "~/Areas/ScBlockVolumeSole/Scripts/btnExecute_onclick.js",
                    "~/Areas/ScBlockVolumeSole/Scripts/Library.js",
                    "~/Areas/ScBlockVolumeSole/Scripts/Ready.js"
                    ));
            BundleTable.Bundles.Add(new Bundle("~/ScBlockVolumeSole/bundles/css").Include(
                    "~/Areas/ScBlockVolumeSole/Content/css.css"
                    ));
        }

        
    }
}