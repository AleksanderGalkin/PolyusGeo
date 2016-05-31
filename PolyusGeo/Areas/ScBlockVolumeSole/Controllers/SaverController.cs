using MyBlog.Controllers;
using Newtonsoft.Json;
using PolyusGeo.bl_server_context;
using PolyusGeo.Infrastructure.UoW;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace PolyusGeo.Areas.ScBlockVolumeSole.Controllers
{
    public class data
    {
        public string BLKNAM { get; set; }
        public string MATERIAL { get; set; }
        public string VOLUME { get; set; }
        public string DATE { get; set; }
        public string COMMENT { get; set; }
        public string TONNES { get; set; }
        public string DENSITY { get; set; }
        public string GC_AU { get; set; }
        public string GC_AS { get; set; }
        public string GC_C { get; set; }
        public string GC_S { get; set; }
        public string GC_FE { get; set; }
        public string ORETYPE { get; set; }
    }

    public class db_data
    {
        public string BLKNAM { get; set; }
        public string MATERIAL { get; set; }
        public string VOLUME { get; set; }
        public string DATE { get; set; }
        public string COMMENT { get; set; }
        public string TONNES { get; set; }
        public string DENSITY { get; set; }
        public string GC_AU { get; set; }
        public string GC_AS { get; set; }
        public string GC_C { get; set; }
        public string GC_S { get; set; }
        public string GC_FE { get; set; }
        public string PIT { get; set; }
    }

    [Export(typeof(IController)),
    ExportMetadata("ControllerName", "Saver")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SaverController : AbstractController
    {
        [ImportingConstructor]
        public SaverController(IUnitOfWork UnitOfWork)
                : base(UnitOfWork)
        {

        }

        public ActionResult Display()
        {
            return View();
        }

        public JsonResult Save(IEnumerable<data> rows)
        {
            string status = "Ok", message = "";

            foreach(var row in rows)
            {
                string s_bench = Regex.Match(row.BLKNAM, @"^.\d{2,3}(?=-)").Value;
                string s_block = Regex.Match(row.BLKNAM, @"(?<=-)\d{3}(?=-)").Value;
                string s_sub_block = Regex.Match(row.BLKNAM, @"(?<=-)\d{1,3}$").Value;
                string s_current_login = Regex.Match(HttpContext.User.Identity.Name,@"(?<=\\)\w{2,}$").Value;

                S_BLOK newItem = new S_BLOK();
                newItem.GORIZONT = _unitOfWork.db.GORIZONT.Where(x => x.BENCH_NAME.ToString() == s_bench).SingleOrDefault();
                newItem.RL_EXPLO2 = _unitOfWork.db.RL_EXPLO2.Where(x => x.EXPL_LINE_NAME == s_block).SingleOrDefault();
                newItem.subBlok = s_sub_block;

                Char separator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.ToCharArray()[0];
                decimal number;
                if( Decimal.TryParse(row.GC_AU, out number))
                {
                    newItem.Ccp = number;
                }
                else 
                {
                    if (Decimal.TryParse(row.GC_AU.Replace(',', separator).Replace('.',separator), out number))
                    {
                        newItem.Ccp = number;
                    }
                    else
                    {
                        _logger.ErrorFormat("GC_AU = {0} is not valid number", row.GC_AU);
                        throw new FormatException(String.Format("GC_AU = {0} is not valid number", row.GC_AU));
                    }
                }

                if (Decimal.TryParse(row.GC_AS, out number))
                {
                    newItem.GC_AS = number;
                }
                else
                {
                    if (Decimal.TryParse(row.GC_AS.Replace(',', separator).Replace('.', separator), out number))
                    {
                        newItem.GC_AS = number;
                    }
                    else
                    {
                        _logger.ErrorFormat("GC_AS = {0} is not valid number", row.GC_AS);
                        throw new FormatException(String.Format("GC_AS = {0} is not valid number", row.GC_AS));
                    }
                }

                if (Decimal.TryParse(row.GC_C, out number))
                {
                    newItem.GC_C = number;
                }
                else
                {
                    if (Decimal.TryParse(row.GC_C.Replace(',', separator).Replace('.', separator), out number))
                    {
                        newItem.GC_C = number;
                    }
                    else
                    {
                        _logger.ErrorFormat("GC_C = {0} is not valid number", row.GC_C);
                        throw new FormatException(String.Format("GC_C = {0} is not valid number", row.GC_C));
                    }
                }

                if (Decimal.TryParse(row.GC_FE, out number))
                {
                    newItem.GC_FE = number;
                }
                else
                {
                    if (Decimal.TryParse(row.GC_FE.Replace(',', separator).Replace('.', separator), out number))
                    {
                        newItem.GC_FE = number;
                    }
                    else
                    {
                        _logger.ErrorFormat("GC_FE = {0} is not valid number", row.GC_FE);
                        throw new FormatException(String.Format("GC_FE = {0} is not valid number", row.GC_FE));
                    }
                }

                if (Decimal.TryParse(row.GC_S, out number))
                {
                    newItem.GC_S = number;
                }
                else
                {
                    if (Decimal.TryParse(row.GC_S.Replace(',', separator).Replace('.', separator), out number))
                    {
                        newItem.GC_S = number;
                    }
                    else
                    {
                        _logger.ErrorFormat("GC_S = {0} is not valid number", row.GC_S);
                        throw new FormatException(String.Format("GC_S = {0} is not valid number", row.GC_S));
                    }
                }

                if (Decimal.TryParse(row.TONNES, out number))
                {
                    newItem.Q = number;
                }
                else
                {
                    if (Decimal.TryParse(row.TONNES.Replace(',', separator).Replace('.', separator), out number))
                    {
                        newItem.Q = number;
                    }
                    else
                    {
                        _logger.ErrorFormat("TONNES = {0} is not valid number", row.TONNES);
                        throw new FormatException(String.Format("TONNES = {0} is not valid number", row.TONNES));
                    }
                }

                if (Decimal.TryParse(row.VOLUME, out number))
                {
                    newItem.V = number;
                }
                else
                {
                    if (Decimal.TryParse(row.VOLUME.Replace(',', separator).Replace('.', separator), out number))
                    {
                        newItem.V = number;
                    }
                    else
                    {
                        _logger.ErrorFormat("VOLUME = {0} is not valid number", row.VOLUME);
                        throw new FormatException(String.Format("VOLUME = {0} is not valid number", row.VOLUME));
                    }
                }

                newItem.M = newItem.Q * newItem.Ccp / 1000;
                newItem.Rang = _unitOfWork.db.RANG.Where(x => x.ENG_RANG == row.MATERIAL).Select(x=>x.ID).SingleOrDefault();
                newItem.END_DATE = DateTime.Parse(row.DATE);
                newItem.Comment = row.COMMENT;
                newItem.Pit = row.ORETYPE == "101" ? 1 : 2;
                newItem.LastDT = DateTime.Now;
                newItem.LastUserID = _unitOfWork.db.GEOLOGIST.Where(x => x.LOGIN == s_current_login).Select(x => x.GEOLOGIST_ID).SingleOrDefault();
                _unitOfWork.db.S_BLOK.Add(newItem);
            }

            var answer = Json(new { status = status, message = message });
            return answer;

        }

        public ActionResult DbViewer()
        {
            return View();
        }

        public JsonResult DbViewerGetRows()
        {
            DateTime filter_date = DateTime.Today.AddDays(-2);

            var eSelect = (from e in _unitOfWork.db.S_BLOK
                           where e.LastDT > filter_date
                           select e)
                           
                          .ToList()
                         .Select(x => new db_data
                         {
                             BLKNAM = x.GORIZONT.BENCH_NAME.ToString() + '-' + x.RL_EXPLO2.EXPL_LINE_NAME + '-' + x.subBlok,
                             VOLUME = (x.V ?? 0).ToString(),
                             TONNES = (x.Q ?? 0).ToString(),
                             DATE = x.END_DATE.ToString(),
                             COMMENT = x.Comment,
                             GC_AU = (x.Ccp ?? 0).ToString(),
                             GC_AS = (x.GC_AS ?? 0).ToString(),
                             GC_C = (x.GC_C ?? 0).ToString(),
                             GC_S = (x.GC_S ?? 0).ToString(),
                             GC_FE = (x.GC_FE ?? 0).ToString(),
                             PIT = x.Pit == 1 ? "Южный" : "Северный"
                         })
                         .ToList();
            return Json(eSelect,JsonRequestBehavior.AllowGet);

        }

        public ActionResult ModalTpl()
        {
            return View();
        }
    }
}