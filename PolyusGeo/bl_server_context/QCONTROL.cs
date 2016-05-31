namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QCONTROL")]
    public partial class QCONTROL
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string SAMPLE { get; set; }

        public double? VES_SAMPLE { get; set; }

        public double? AU { get; set; }

        public double? AU_CUT { get; set; }

        public double? As { get; set; }

        public double? Sb { get; set; }

        public double? S { get; set; }

        public double? Ca { get; set; }

        public double? Fe { get; set; }

        public double? Ag { get; set; }

        public double? C { get; set; }

        public int BLANK { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public virtual REESTR_VEDOMOSTEI REESTR_VEDOMOSTEI { get; set; }
    }
}
