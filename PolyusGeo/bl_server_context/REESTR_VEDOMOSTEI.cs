namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class REESTR_VEDOMOSTEI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REESTR_VEDOMOSTEI()
        {
            ASSAYS = new HashSet<ASSAYS>();
            ASSAYS_DMP = new HashSet<ASSAYS_DMP>();
            ASSAYS_OR = new HashSet<ASSAYS_OR>();
            ASSAYS2 = new HashSet<ASSAYS2>();
            ASSAYS2_CS = new HashSet<ASSAYS2_CS>();
            QCONTROL = new HashSet<QCONTROL>();
            QFACE = new HashSet<QFACE>();
            RV_GEO = new HashSet<RV_GEO>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string BLANK_ID { get; set; }

        public DateTime? DATE_FORW { get; set; }

        [StringLength(255)]
        public string PLACE { get; set; }

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
        public virtual ICollection<ASSAYS> ASSAYS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSAYS_DMP> ASSAYS_DMP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSAYS_OR> ASSAYS_OR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSAYS2> ASSAYS2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSAYS2_CS> ASSAYS2_CS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QCONTROL> QCONTROL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QFACE> QFACE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RV_GEO> RV_GEO { get; set; }
    }
}
