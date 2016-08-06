using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolyusGeo.Areas.Bl_DhSample.Models
{
    public class Dtm_Dh_Or
    {
        public Dtm_Dh_Or_Collar Dtm_Dh_Or_Collar { get; set; }
        public IList<Dtm_Dh_Or_Survey> Dtm_Dh_Or_Surveys { get; set; }
        public IList<Dtm_Dh_Or_Assay> Dtm_Dh_Or_Assays { get; set; }
    }
    public class Dtm_Dh_Or_Collar
    {
        public string Bhid { get; set; }
        public float Xcollar { get; set; }
        public float Ycollar { get; set; }
        public float Zcollar { get; set; }
        public float Enddepth { get; set; }
        public int Domen { get; set; }
    }

    public class Dtm_Dh_Or_Survey
    {
        public string Bhid { get; set; }
        public float At { get; set; }
        public float Brg { get; set; }
        public float Dip { get; set; }
    }

    public class Dtm_Dh_Or_Assay
    {
        public string Bhid { get; set; }
        public string Sample { get; set; }
        public float From { get; set; }
        public float To { get; set; }
        public float Length { get; set; }
        public int Rock { get; set; }
        public int Pit { get; set; }
    }
        
    

}