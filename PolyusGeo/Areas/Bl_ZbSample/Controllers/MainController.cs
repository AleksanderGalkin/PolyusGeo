using MyBlog.Controllers;
using PolyusGeo.Infrastructure.UoW;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolyusGeo.Areas.Bl_ZbSample.Controllers
{
    [Export(typeof(IController)),
   ExportMetadata("ControllerName", "Bl_Zb_Main")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class Bl_Zb_MainController : AbstractController
    {
        [ImportingConstructor]
        public Bl_Zb_MainController(IUnitOfWork UnitOfWork)
                : base(UnitOfWork)
        {

        }
        // GET: Bl_ZbSample/Main
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

        public JsonResult GetSectors()
        {


            var eSelect = (from e in _unitOfWork.db.SECTOR
                               select e)

                          .ToList()
                         .Select(x => x.SECTOR1)
                         .ToList();

 

            return Json(eSelect, JsonRequestBehavior.AllowGet);

        }
    }


    
  
}