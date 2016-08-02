
using PolyusGeo.bl_server_context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PolyusGeo.Infrastructure.UoW
{
    public interface IDbContext:IDisposable
    {
        IDbSet<S_BLOK> S_BLOK { get; set; }
        IDbSet<GORIZONT> GORIZONT { get; set; }
        IDbSet<RL_EXPLO2> RL_EXPLO2 { get; set; }
        IDbSet<RANG> RANG { get; set; }
        IDbSet<GEOLOGIST> GEOLOGIST { get; set; }
        IDbSet<SECTOR> SECTOR { get; set; }
        int SaveChanges();
    }
}