using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.magazine;
using Wolf.Lagash.Interfaces;

namespace Wolf.Lagash.Services
{
    public class MagazineEjemplarService : EFAdapterBase<MagazineEjemplar>, IMagazineEjemplarService
    {
        public MagazineEjemplarService(DbContext Context) : base(Context)
        {
        }

        public bool exists(String id)
        {
            return context.Set<MagazineEjemplar>().Count(e => e._id == id) > 0;
        }

        public IEnumerable<MagazineEjemplar> select(int start, int end)
        {
            return context.Set<MagazineEjemplar>().OrderByDescending(o => o.inventory).Where(o => o.inventory <= start && o.inventory >= end);
        }

        public MagazineEjemplar next()
        {
            return context.Set<MagazineEjemplar>().OrderByDescending(o => o.inventory).FirstOrDefault();
        }
    }
}
