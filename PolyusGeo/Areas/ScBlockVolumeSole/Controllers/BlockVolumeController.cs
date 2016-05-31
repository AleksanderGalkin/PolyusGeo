using MyBlog.Controllers;
using PolyusGeo.Infrastructure.UoW;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolyusGeo.Areas.ScBlockVolumeSole.Controllers
{
    [Export(typeof(IController)),
    ExportMetadata("ControllerName", "BlockVolume")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BlockVolumeController : AbstractController
    {
        [ImportingConstructor]
        public BlockVolumeController(IUnitOfWork UnitOfWork)
                : base(UnitOfWork)
        {

        }

        // GET: BlockVolume
        public ActionResult Index()
        {
            return View();
        }
    }
}