namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RL_EXPLO2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RL_EXPLO2()
        {
            COLLAR2 = new HashSet<COLLAR2>();
            S_BLOK = new HashSet<S_BLOK>();
            S_DAY = new HashSet<S_DAY>();
        }

        [Key]
        public int EX_LINE_COD { get; set; }

        [StringLength(4)]
        public string EXPL_LINE_NAME { get; set; }

        public DateTime? EXPL_LINE_DATE { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COLLAR2> COLLAR2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<S_BLOK> S_BLOK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<S_DAY> S_DAY { get; set; }
    }
}
