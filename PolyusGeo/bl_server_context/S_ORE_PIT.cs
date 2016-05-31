namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class S_ORE_PIT
    {
        [Key]
        public int Код { get; set; }

        public DateTime? END_DATE { get; set; }

        public int? SMENA { get; set; }

        public int? Sektor { get; set; }

        public int? R_zone { get; set; }

        public double? Sektor1 { get; set; }

        public double? Sektor2 { get; set; }

        public double? Bunker1 { get; set; }

        public double? Bunker2 { get; set; }

        public double? Mill1 { get; set; }

        public double? Mill2 { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public virtual Q_sm Q_sm { get; set; }

        public virtual Q_zone Q_zone { get; set; }

        public virtual SECTOR SECTOR { get; set; }
    }
}
