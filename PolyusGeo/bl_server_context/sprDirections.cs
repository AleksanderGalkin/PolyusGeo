namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sprDirections
    {
        public int id { get; set; }

        public int AreaID { get; set; }

        [Required]
        [StringLength(2)]
        public string Direction { get; set; }

        public int? RepPlace { get; set; }

        public int? GroupID { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        public virtual sprAreas sprAreas { get; set; }

        public virtual sprOreRepGroups sprOreRepGroups { get; set; }
    }
}
