namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RV_PAL_STRG
    {
        [Key]
        public int ID_RV_PAL { get; set; }

        public int ID_RV_GEO { get; set; }

        [StringLength(15)]
        public string Au { get; set; }

        [StringLength(15)]
        public string As { get; set; }

        [StringLength(15)]
        public string mAu1 { get; set; }

        [StringLength(15)]
        public string mAu2 { get; set; }

        [StringLength(15)]
        public string mAu3 { get; set; }

        [StringLength(15)]
        public string mAu4 { get; set; }

        [StringLength(15)]
        public string Sb { get; set; }

        [StringLength(15)]
        public string S { get; set; }

        [StringLength(15)]
        public string Ca { get; set; }

        [StringLength(15)]
        public string Fe { get; set; }

        [StringLength(15)]
        public string Ag { get; set; }

        [StringLength(15)]
        public string C { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public virtual RV_GEO_STRG RV_GEO_STRG { get; set; }
    }
}
