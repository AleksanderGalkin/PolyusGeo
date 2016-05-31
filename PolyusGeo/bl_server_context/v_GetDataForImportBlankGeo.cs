namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_GetDataForImportBlankGeo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string sample { get; set; }

        public double? ves { get; set; }

        [StringLength(15)]
        public string au { get; set; }

        [Column("as")]
        [StringLength(15)]
        public string _as { get; set; }

        [StringLength(15)]
        public string s { get; set; }

        [StringLength(15)]
        public string c { get; set; }

        [StringLength(15)]
        public string Fe { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string blank_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string wsname { get; set; }
    }
}
