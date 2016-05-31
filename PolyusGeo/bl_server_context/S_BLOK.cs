namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class S_BLOK
    {
        public int ID { get; set; }

        public int Pit { get; set; }

        public DateTime? END_DATE { get; set; }

        public int Bench { get; set; }

        public int Blok { get; set; }

        [Required]
        [StringLength(2)]
        public string subBlok { get; set; }

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

        [Required]
        [StringLength(255)]
        public string Comment { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public virtual GORIZONT GORIZONT { get; set; }

        public virtual RL_EXPLO2 RL_EXPLO2 { get; set; }
    }
}
