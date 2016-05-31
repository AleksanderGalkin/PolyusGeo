namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class S_SALDO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AreaID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime DateSaldo { get; set; }

        public decimal V { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        public virtual sprAreas sprAreas { get; set; }
    }
}
