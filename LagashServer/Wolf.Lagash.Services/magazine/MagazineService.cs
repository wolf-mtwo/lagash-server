using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Entities.books;
using Wolf.Lagash.Interfaces;

namespace Wolf.Lagash.Services
{
    public class MagazineService : EFAdapterBase<Magazine>, IMagazineService
    {
        public MagazineService(DbContext Context) : base(Context)
        {
        }

        public bool exists(String id)
        {
            return context.Set<Magazine>().Count(e => e._id == id) > 0;
        }

        public IEnumerable<Magazine> search(int page, int limit, Func<Magazine, bool> where)
        {
            page--;
            return context.Set<Magazine>().Where(o => o.enabled).OrderByDescending(o => o.created).Where(where).Skip(page * limit).Take(limit);
        }
    }
}
