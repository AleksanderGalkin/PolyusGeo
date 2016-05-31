namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_GetCombinedOreFlowStrgSum
    {
        [StringLength(35)]
        public string bind { get; set; }

        [Key]
        [Column(Order = 0)]
        public DateTime fDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SmenaId { get; set; }

        public decimal? vol { get; set; }

        public double? ccp { get; set; }

        public decimal? m { get; set; }
    }
}
