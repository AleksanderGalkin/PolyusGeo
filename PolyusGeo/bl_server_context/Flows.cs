namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Flows
    {
        public int id { get; set; }

        public int Kre { get; set; }

        public int Deb { get; set; }

        public decimal Vol { get; set; }

        public DateTime fDate { get; set; }

        public decimal? Ccp { get; set; }

        public decimal? M { get; set; }

        public int SmenaId { get; set; }

        public int? LastUserID { get; set; }

        public DateTime? LastDT { get; set; }

        public virtual Q_sm Q_sm { get; set; }

        public virtual sprAreas sprAreas { get; set; }

        public virtual sprAreas sprAreas1 { get; set; }
    }
}
