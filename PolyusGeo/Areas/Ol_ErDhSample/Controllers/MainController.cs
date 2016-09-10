using MyBlog.Controllers;
using PolyusGeo.Infrastructure.UoW;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolyusGeo.Areas.Ol_ErDhSample.Controllers
{
    [Export(typeof(IController)),
   ExportMetadata("ControllerName", "Ol_ErDhSample_Main_")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class Ol_ErDhSample_Main_Controller : AbstractController
    {
        [ImportingConstructor]
        public Ol_ErDhSample_Main_Controller(IUnitOfWork UnitOfWork)
                : base(UnitOfWork)
        {

        }
        // GET: Ol_ErDhSample/Main
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
    }


    
  
}