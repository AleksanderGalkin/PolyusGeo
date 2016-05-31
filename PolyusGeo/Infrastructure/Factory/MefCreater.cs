using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.Mvc;

namespace PolyusGeo.Infrastructure.Factory
{
    
    public static class MefCreater
    {
        private static AggregateCatalog AggregateCatalog;
        private static  CompositionContainer _container;




        static MefCreater()
        {

        }

        public static void InitFactory()
        {
            AggregateCatalog = new AggregateCatalog();
            AssemblyCatalog AssemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            AggregateCatalog.Catalogs.Add(AssemblyCatalog);
            _container = new CompositionContainer(AggregateCatalog);

  
            

        }
      
        public static IController GetController (string ControllerName)
        {
            IController controller = null;


            var e1 = _container.GetExports<IController, IMetadata>();
            var e2 = e1.Where(e => e.Metadata.ControllerName.Equals(ControllerName));
            var export = e2.SingleOrDefault();
            if (export != null)
            {
                controller = export.Value as IController;

            }

            //if (controller == null)
            //{
            //    var export_not_plugin = _container.GetExports<IController, IMetadata>()
            //        .Where(e => e.Metadata.ControllerName.Equals(ControllerName))
            //        .SingleOrDefault();
            //    if (export_not_plugin != null)
            //    {
            //        controller = export_not_plugin.Value as IController;
            //    }
            //}

            return controller;
        }

    }
}