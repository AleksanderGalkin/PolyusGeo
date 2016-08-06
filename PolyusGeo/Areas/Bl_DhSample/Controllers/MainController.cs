using MyBlog.Controllers;
using PolyusGeo.Areas.Bl_DhSample.Models;
using PolyusGeo.Infrastructure.UoW;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolyusGeo.Areas.Bl_DhSample.Controllers
{
    [Export(typeof(IController)),
   ExportMetadata("ControllerName", "Main")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainController : AbstractController
    {
        [ImportingConstructor]
        public MainController(IUnitOfWork UnitOfWork)
                : base(UnitOfWork)
        {

        }
        // GET: Bl_DhSample/Main
        public ActionResult StartPage()
        {
            return View();
        }

        public ActionResult ModalTpl()
        {
            return View();
        }
        public ActionResult ModalTplRows()
        {
            return View();
        }

        public ActionResult Saver()
        {
            return View();
        }


        public JsonResult SaveDh(Dtm_Dh_Or InModel)
        {
            SaveDhResult json_result = new SaveDhResult();





            return Json(json_result, JsonRequestBehavior.AllowGet);

        }

    }


    
  
}