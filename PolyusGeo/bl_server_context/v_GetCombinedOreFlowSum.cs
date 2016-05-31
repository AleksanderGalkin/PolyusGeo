namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_GetCombinedOreFlowSum
    {
        [StringLength(7)]
        public string bind { get; set; }

        [Key]
        [Column(Order = 0)]
        public decimal Vol { get; set; }

        public decimal? Ccp { get; set; }

        public decimal? M { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime fDate { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SmenaId { get; set; }
    }
}
