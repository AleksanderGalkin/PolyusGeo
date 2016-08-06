using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using PolyusGeo.Areas.Bl_DhSample.Controllers;
using PolyusGeo.Areas.Bl_DhSample.Models;
using PolyusGeo.bl_server_context;
using PolyusGeo.Infrastructure.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PolyusGeo.Areas.Bl_DhSample.Controllers.Tests
{
    [TestClass()]
    public class MainControllerTests
    {
        IDbContext _ds;
        IUnitOfWork UoW;
        MainController controller;

        [TestInitialize]
        public  void Init()
        {
            _ds = Substitute.For<IDbContext>();
            IList<COLLAR_OR> collar_model = new List<COLLAR_OR> { new COLLAR_OR(), new COLLAR_OR() };
            UoW = new UnitOfWork(_ds);
        }

        [TestMethod()]
        public void SaveDhTest()
        {
            var nCollar_before = _ds.COLLAR_OR.Count();
            var nSurveys_before = _ds.SURVEYS_OR.Count();
            var nAssays_before = _ds.ASSAYS_OR.Count();

            controller = new MainController(UoW);
            Dtm_Dh_Or dh_or_data = new Dtm_Dh_Or();
            dh_or_data.Dtm_Dh_Or_Collar = new Dtm_Dh_Or_Collar();
            dh_or_data.Dtm_Dh_Or_Surveys = new List< Dtm_Dh_Or_Survey >{ new Dtm_Dh_Or_Survey()};
            dh_or_data.Dtm_Dh_Or_Assays = new List<Dtm_Dh_Or_Assay> { new Dtm_Dh_Or_Assay(), new Dtm_Dh_Or_Assay() };
            var json_result = controller.SaveDh(dh_or_data) as JsonResult;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            SaveDhResult result = serializer.Deserialize<SaveDhResult>(serializer.Serialize(json_result.Data));

            var nCollar_after = _ds.COLLAR_OR.Count();
            var nSurveys_after = _ds.SURVEYS_OR.Count();
            var nAssays_after = _ds.ASSAYS_OR.Count();

            Assert.AreEqual(1, nCollar_after - nCollar_before);
            Assert.AreEqual(1, nSurveys_after - nSurveys_before);
            Assert.AreEqual(1, nAssays_after - nAssays_before);

            Assert.AreEqual(0, result.Code);
            Assert.IsNull(result.Message);
        }
    }
}