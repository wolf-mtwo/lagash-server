using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.books;
using Wolf.Lagash.Interfaces.books;

namespace Wolf.Lagash.Services.books
{
    public class BookEjemplarService : EFAdapterBase<BookEjemplar>, IBookEjemplarService
    {
        public BookEjemplarService(DbContext Context) : base(Context)
        {
        }

        public bool exists(string id)
        {
            return context.Set<BookEjemplar>().Count(e => e._id == id) > 0;
        }

        public IEnumerable<BookEjemplar> select(int start, int end)
        {
            return context.Set<BookEjemplar>().OrderByDescending(o => o.inventory).Where(o => o.inventory <= start && o.inventory >= end);
        }

        public BookEjemplar next()
        {
            return context.Set<BookEjemplar>().OrderByDescending(o => o.inventory).FirstOrDefault();
        }
    }
}
