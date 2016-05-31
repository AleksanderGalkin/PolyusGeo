using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolyusGeo.Infrastructure.Helpers
{
    public static class UrlExtension
    { 
        public static string AreaContent(this UrlHelper url, string imagePath)
        {
            var area = url.RequestContext.RouteData.DataTokens["area"].ToString();
            if (!string.IsNullOrEmpty(area))
                area = "Areas/" + area + "/";
            return VirtualPathUtility.ToAbsolute("~/" + area + "Content/" + imagePath);
        }
    }
}