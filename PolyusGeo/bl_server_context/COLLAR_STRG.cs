namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COLLAR_STRG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COLLAR_STRG()
        {
            ASSAYS_STRG = new HashSet<ASSAYS_STRG>();
            SURVEYS_STRG = new HashSet<SURVEYS_STRG>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string BHID { get; set; }

        public double XCOLLAR { get; set; }

        public double YCOLLAR { get; set; }

        public double ZCOLLAR { get; set; }

        public double ENDDEPTH { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSAYS_STRG> ASSAYS_STRG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SURVEYS_STRG> SURVEYS_STRG { get; set; }
    }
}
