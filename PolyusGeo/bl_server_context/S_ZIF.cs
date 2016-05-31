namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class S_ZIF
    {
        [Key]
        public int Код { get; set; }

        public DateTime? END_DATE { get; set; }

        public int? Smena { get; set; }

        public double? Q_ZIF { get; set; }

        public double? Ccp { get; set; }

        public double? M { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public virtual Q_sm Q_sm { get; set; }
    }
}
