namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COLLAR_OR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COLLAR_OR()
        {
            ASSAYS_OR = new HashSet<ASSAYS_OR>();
            SURVEYS_OR = new HashSet<SURVEYS_OR>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(25)]
        public string BHID { get; set; }

        public double XCOLLAR { get; set; }

        public double YCOLLAR { get; set; }

        public double ZCOLLAR { get; set; }

        public double ENDDEPTH { get; set; }

        public int DOMEN { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [StringLength(20)]
        public string host { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSAYS_OR> ASSAYS_OR { get; set; }

        public virtual DOMEN DOMEN1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SURVEYS_OR> SURVEYS_OR { get; set; }
    }
}
