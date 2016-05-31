namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ASSAYS_DMP
    {
        public int ID { get; set; }

        public int BHID { get; set; }

        [Required]
        [StringLength(255)]
        public string SAMPLE { get; set; }

        public int? SECTOR { get; set; }

        public double? FROM { get; set; }

        public double? TO { get; set; }

        public double? LENGTH { get; set; }

        public double? VES_SAMPLE { get; set; }

        public double? Au { get; set; }

        public int BLANK { get; set; }

        public DateTime? END_DATE { get; set; }

        public int? GEOLOGIST { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public virtual COLLAR_DMP COLLAR_DMP { get; set; }

        public virtual GEOLOGIST GEOLOGIST1 { get; set; }

        public virtual REESTR_VEDOMOSTEI REESTR_VEDOMOSTEI { get; set; }

        public virtual SECTOR SECTOR1 { get; set; }
    }
}
