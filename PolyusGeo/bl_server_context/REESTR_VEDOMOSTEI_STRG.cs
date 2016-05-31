namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class REESTR_VEDOMOSTEI_STRG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REESTR_VEDOMOSTEI_STRG()
        {
            ASSAYS_STRG = new HashSet<ASSAYS_STRG>();
            RV_GEO_STRG = new HashSet<RV_GEO_STRG>();
            SFACE = new HashSet<SFACE>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string BLANK_ID { get; set; }

        public DateTime? DATE_FORW { get; set; }

        [StringLength(255)]
        public string PLACE { get; set; }

        public int? MOVER { get; set; }

        public int? SECTOR { get; set; }

        public int? GEOLOGIST { get; set; }

        [StringLength(255)]
        public string PROT_NUM { get; set; }

        public DateTime? PROT_DAT { get; set; }

        public DateTime? POSTUP_DAT { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSAYS_STRG> ASSAYS_STRG { get; set; }

        public virtual GEOLOGIST GEOLOGIST1 { get; set; }

        public virtual MOVER MOVER1 { get; set; }

        public virtual SECTOR SECTOR1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RV_GEO_STRG> RV_GEO_STRG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SFACE> SFACE { get; set; }
    }
}
