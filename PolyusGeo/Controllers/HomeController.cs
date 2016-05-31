using MyBlog.Controllers;
using PolyusGeo.Infrastructure.UoW;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolyusGeo.Controllers
{
    [Export(typeof(IController)),
    ExportMetadata("ControllerName", "Home")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : AbstractController
    {
        [ImportingConstructor]
        public HomeController(IUnitOfWork UnitOfWork)
                : base(UnitOfWork)
        {
 
        }
        public ActionResult Index()
        {
            return View();
        }

     
    }
}