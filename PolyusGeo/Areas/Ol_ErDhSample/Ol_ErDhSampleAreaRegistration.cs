using System.Web.Mvc;
using System.Web.Optimization;

namespace PolyusGeo.Areas.Ol_ErDhSample
{
    public class Ol_ErDhSampleAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Ol_ErDhSample";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Ol_ErDhSample_default",
                "Ol_ErDhSample/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                                namespaces: new[] { "PolyusGeo.Areas.Ol_ErDhSample.Controllers" }
            );

            BundleTable.Bundles.Add(new Bundle("~/Ol_ErDhSample/bundles/scripts").Include(
                       "~/Areas/Ol_ErDhSample/Scripts/AutoConnect.js",
                       "~/Areas/Ol_ErDhSample/Scripts/btnExecute_onclick.js",
                       "~/Areas/Ol_ErDhSample/Scripts/Library.js",
                       "~/Areas/Ol_ErDhSample/Scripts/ang_app.js",
                       "~/Areas/Ol_ErDhSample/Scripts/Ready.js"
                       ));
            BundleTable.Bundles.Add(new Bundle("~/Ol_ErDhSample/bundles/css").Include(
                        "~/Areas/Ol_ErDhSample/Content/css.css"
                        ));
        }
    }
}