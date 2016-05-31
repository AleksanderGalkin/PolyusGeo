namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DUMP_BALANS
    {
        public int ID { get; set; }

        public int? Sort { get; set; }

        public int? Year { get; set; }

        public int? Dat { get; set; }

        public double? Q_d { get; set; }

        public double? Ccp_d { get; set; }

        public double? M_d { get; set; }

        public double? Q_p { get; set; }

        public double? Ccp_p { get; set; }

        public double? M_p { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public virtual Q_Mes Q_Mes { get; set; }

        public virtual Q_YEAR Q_YEAR { get; set; }
    }
}
