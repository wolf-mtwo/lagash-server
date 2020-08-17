using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.newspaper;
using Wolf.Lagash.Interfaces;

namespace Wolf.Lagash.Services
{
    public class NewspaperEjemplarService : EFAdapterBase<NewspaperEjemplar>, INewspaperEjemplarService
    {
        public NewspaperEjemplarService(DbContext Context) : base(Context)
        {
        }

        public bool exists(String id)
        {
            return context.Set<NewspaperEjemplar>().Count(e => e._id == id) > 0;
        }

        public IEnumerable<NewspaperEjemplar> select(int start, int end)
        {
            return context.Set<NewspaperEjemplar>().OrderByDescending(o => o.inventory).Where(o => o.inventory <= start && o.inventory >= end);
        }

        public NewspaperEjemplar next()
        {
            return context.Set<NewspaperEjemplar>().OrderByDescending(o => o.inventory).FirstOrDefault();
        }
    }
}
