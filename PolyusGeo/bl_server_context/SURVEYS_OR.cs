namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SURVEYS_OR
    {
        public int ID { get; set; }

        public int BHID { get; set; }

        public int? AT { get; set; }

        public int? BRG { get; set; }

        public int? DIP { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [StringLength(20)]
        public string host { get; set; }

        public virtual COLLAR_OR COLLAR_OR { get; set; }
    }
}
