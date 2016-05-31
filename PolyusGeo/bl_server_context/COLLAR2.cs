namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COLLAR2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COLLAR2()
        {
            ASSAYS2 = new HashSet<ASSAYS2>();
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

        public int DRILL_TYPE { get; set; }

        public int DOMEN { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        [StringLength(50)]
        public string Host { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSAYS2> ASSAYS2 { get; set; }

        public virtual DOMEN DOMEN1 { get; set; }

        public virtual DRILLING_TYPE DRILLING_TYPE { get; set; }

        public virtual GORIZONT GORIZONT { get; set; }

        public virtual RL_EXPLO2 RL_EXPLO2 { get; set; }
    }
}
