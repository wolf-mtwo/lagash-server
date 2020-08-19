using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.thesis;
using Wolf.Lagash.Interfaces.thesis;

namespace Wolf.Lagash.Services.thesis
{
    public class ThesisService : EFAdapterBase<Thesis>, IThesisService
    {
        public ThesisService(DbContext Context) : base(Context)
        {
        }

        public bool exists(string id)
        {
            return context.Set<Thesis>().Count(e => e._id == id) > 0;
        }

        public IEnumerable<Thesis> suggestions()
        {
            return context.Set<Thesis>().Where(o => o.enabled).OrderByDescending(o => o.created).Skip(0).Take(10);
        }

        public IEnumerable<Thesis> search(int page, int limit, Func<Thesis, bool> where)
        {
            page--;
            return context.Set<Thesis>().Where(o => o.enabled).OrderByDescending(o => o.created).Where(where).Skip(page * limit).Take(limit);
        }
    }
}
