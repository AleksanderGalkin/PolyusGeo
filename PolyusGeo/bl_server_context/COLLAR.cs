namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COLLAR")]
    public partial class COLLAR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COLLAR()
        {
            ASSAYS = new HashSet<ASSAYS>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string BHID { get; set; }

        public int BENCH_ID { get; set; }

        public int LINE_ID { get; set; }

        public int HOLE_ID { get; set; }

        public double XCOLLAR { get; set; }

        public double YCOLLAR { get; set; }

        public double ZCOLLAR { get; set; }

        public double ENDDEPTH { get; set; }

        public int? DRILL_TYPE { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSAYS> ASSAYS { get; set; }

        public virtual DRILLING_TYPE DRILLING_TYPE { get; set; }

        public virtual GORIZONT GORIZONT { get; set; }

        public virtual HOLE HOLE { get; set; }

        public virtual RL_EXPLO RL_EXPLO { get; set; }
    }
}
