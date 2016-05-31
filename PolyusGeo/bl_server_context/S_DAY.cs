namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class S_DAY
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int Pit { get; set; }

        [Key]
        [Column(Order = 0)]
        public DateTime END_DATE { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Smena { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Mover { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Bench { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Blok { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(2)]
        public string subBlok { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rang { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? V { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Q { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Ccp { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? M { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GC_AS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GC_C { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GC_S { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GC_FE { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [StringLength(20)]
        public string Host { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public virtual GORIZONT GORIZONT { get; set; }

        public virtual MOVER MOVER1 { get; set; }

        public virtual Q_pit Q_pit { get; set; }

        public virtual Q_sm Q_sm { get; set; }

        public virtual RL_EXPLO2 RL_EXPLO2 { get; set; }
    }
}
