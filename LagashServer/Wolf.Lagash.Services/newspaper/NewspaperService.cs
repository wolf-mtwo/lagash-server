using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.newspaper;
using Wolf.Lagash.Interfaces.newspaper;

namespace Wolf.Lagash.Services.newspaper
{
    public class NewspaperService : EFAdapterBase<Newspaper>, INewspaperService
    {
        public NewspaperService(DbContext Context) : base(Context)
        {
        }

        public bool exists(string id)
        {
            return context.Set<Newspaper>().Count(e => e._id == id) > 0;
        }

        public IEnumerable<Newspaper> search(int page, int limit, Func<Newspaper, bool> where)
        {
            page--;
            return context.Set<Newspaper>().Where(o => o.enabled).OrderByDescending(o => o.created).Where(where).Skip(page * limit).Take(limit);
        }
    }
}
