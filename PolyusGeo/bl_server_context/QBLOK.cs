namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QBLOK")]
    public partial class QBLOK
    {
        public int ID { get; set; }

        public int? BENCH { get; set; }

        public int? CATEGORY { get; set; }

        public double? d { get; set; }

        public double? V { get; set; }

        public double? Q { get; set; }

        public double? Ccp { get; set; }

        public double? M { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public virtual GORIZONT GORIZONT { get; set; }
    }
}
