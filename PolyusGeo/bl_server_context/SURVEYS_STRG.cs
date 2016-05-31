namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SURVEYS_STRG
    {
        public int ID { get; set; }

        public int BHID { get; set; }

        public int? AT { get; set; }

        public int? BRG { get; set; }

        public int? DIP { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public virtual COLLAR_STRG COLLAR_STRG { get; set; }
    }
}
