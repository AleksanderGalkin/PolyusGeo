namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RV_GEO_STRG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RV_GEO_STRG()
        {
            RV_GRP_STRG = new HashSet<RV_GRP_STRG>();
            RV_PAL_STRG = new HashSet<RV_PAL_STRG>();
        }

        [Key]
        public int ID_RV_GEO { get; set; }

        public int BLANK_ID { get; set; }

        [Required]
        [StringLength(15)]
        public string SAMPLE { get; set; }

        public int? SFROM { get; set; }

        public int? STO { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public virtual REESTR_VEDOMOSTEI_STRG REESTR_VEDOMOSTEI_STRG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RV_GRP_STRG> RV_GRP_STRG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RV_PAL_STRG> RV_PAL_STRG { get; set; }
    }
}
