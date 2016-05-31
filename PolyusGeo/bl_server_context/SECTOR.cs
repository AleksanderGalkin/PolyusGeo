namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SECTOR")]
    public partial class SECTOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SECTOR()
        {
            ASSAYS_DMP = new HashSet<ASSAYS_DMP>();
            REESTR_VEDOMOSTEI_STRG = new HashSet<REESTR_VEDOMOSTEI_STRG>();
            S_ORE_PIT = new HashSet<S_ORE_PIT>();
        }

        public int ID { get; set; }

        [Column("SECTOR")]
        [Required]
        [StringLength(255)]
        public string SECTOR1 { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSAYS_DMP> ASSAYS_DMP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REESTR_VEDOMOSTEI_STRG> REESTR_VEDOMOSTEI_STRG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<S_ORE_PIT> S_ORE_PIT { get; set; }
    }
}
