namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QFACE")]
    public partial class QFACE
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string SAMPLE { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MOVER { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BENCH_ID { get; set; }

        [Key]
        [Column(Order = 4)]
        public double FROM { get; set; }

        [Key]
        [Column(Order = 5)]
        public double TO { get; set; }

        [Key]
        [Column(Order = 6)]
        public double LENGTH { get; set; }

        public double? VES_SAMPLE { get; set; }

        public double? AU { get; set; }

        public double? AS { get; set; }

        public double? Sb { get; set; }

        public double? S { get; set; }

        public double? Ca { get; set; }

        public double? Fe { get; set; }

        public double? Ag { get; set; }

        public double? C { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BLANK { get; set; }

        public DateTime? END_DATE { get; set; }

        public int? GEOLOGIST { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public virtual GEOLOGIST GEOLOGIST1 { get; set; }

        public virtual GORIZONT GORIZONT { get; set; }

        public virtual MOVER MOVER1 { get; set; }

        public virtual REESTR_VEDOMOSTEI REESTR_VEDOMOSTEI { get; set; }
    }
}
