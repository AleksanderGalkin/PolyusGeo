namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GEOLOGIST")]
    public partial class GEOLOGIST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GEOLOGIST()
        {
            ASSAYS = new HashSet<ASSAYS>();
            ASSAYS_DMP = new HashSet<ASSAYS_DMP>();
            ASSAYS_OR = new HashSet<ASSAYS_OR>();
            ASSAYS2 = new HashSet<ASSAYS2>();
            QFACE = new HashSet<QFACE>();
            REESTR_VEDOMOSTEI_STRG = new HashSet<REESTR_VEDOMOSTEI_STRG>();
            SFACE = new HashSet<SFACE>();
        }

        [Key]
        public int GEOLOGIST_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string GEOLOGIST_NAME { get; set; }

        [Required]
        [StringLength(255)]
        public string LOGIN { get; set; }

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
        public virtual ICollection<QFACE> QFACE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REESTR_VEDOMOSTEI_STRG> REESTR_VEDOMOSTEI_STRG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SFACE> SFACE { get; set; }
    }
}
