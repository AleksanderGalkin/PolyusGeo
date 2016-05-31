namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RV_GEO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RV_GEO()
        {
            RV_GRP = new HashSet<RV_GRP>();
            RV_PAL = new HashSet<RV_PAL>();
        }

        [Key]
        public int ID_RV_GEO { get; set; }

        public int BLANK_ID { get; set; }

        [Required]
        [StringLength(15)]
        public string SAMPLE { get; set; }

        public int? SFROM { get; set; }

        public int? STO { get; set; }

        [StringLength(12)]
        public string BLAST { get; set; }

        [StringLength(12)]
        public string HOLE { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public virtual REESTR_VEDOMOSTEI REESTR_VEDOMOSTEI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RV_GRP> RV_GRP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RV_PAL> RV_PAL { get; set; }
    }
}
