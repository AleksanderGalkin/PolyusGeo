namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ASSAYS2
    {
        public int ID { get; set; }

        public int BHID { get; set; }

        [StringLength(25)]
        public string KEY { get; set; }

        [Required]
        [StringLength(50)]
        public string SAMPLE { get; set; }

        public double FROM { get; set; }

        public double TO { get; set; }

        public double LENGTH { get; set; }

        public int? RESERVERS_BLOCK { get; set; }

        public int ROCK { get; set; }

        public int? RANG { get; set; }

        public double? VES_SAMPLE { get; set; }

        public double? Au { get; set; }

        public double? Au_cut { get; set; }

        public double? As { get; set; }

        public double? Sb { get; set; }

        public double? S { get; set; }

        public double? Ca { get; set; }

        public double? Fe { get; set; }

        public double? Ag { get; set; }

        public double? C { get; set; }

        public DateTime END_DATE { get; set; }

        public int BLANK_ID { get; set; }

        public int JOURNAL { get; set; }

        public int GEOLOGIST { get; set; }

        [StringLength(255)]
        public string PIT { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        [StringLength(50)]
        public string Host { get; set; }

        public virtual BLOCK_ZAPASOV BLOCK_ZAPASOV { get; set; }

        public virtual COLLAR2 COLLAR2 { get; set; }

        public virtual GEOLOGIST GEOLOGIST1 { get; set; }

        public virtual JOURNAL JOURNAL1 { get; set; }

        public virtual LITOLOGY LITOLOGY { get; set; }

        public virtual RANG RANG1 { get; set; }

        public virtual REESTR_VEDOMOSTEI REESTR_VEDOMOSTEI { get; set; }
    }
}
