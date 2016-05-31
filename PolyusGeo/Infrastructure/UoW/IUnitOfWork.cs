using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolyusGeo.Infrastructure.UoW
{
    public interface IUnitOfWork
    {
        IDbContext db { get; }
        void BeginTransaction();
        void Commit();

    }
}