namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sprOreRepGroups
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sprOreRepGroups()
        {
            sprDirections = new HashSet<sprDirections>();
        }

        public int id { get; set; }

        public int? AreaID { get; set; }

        public int RepPlace { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sprDirections> sprDirections { get; set; }
    }
}
