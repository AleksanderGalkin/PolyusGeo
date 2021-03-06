﻿using MyBlog.Controllers;
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
    }


    
  
}