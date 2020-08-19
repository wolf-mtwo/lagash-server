using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.books;
using Wolf.Lagash.Interfaces.books;

namespace Wolf.Lagash.Services.books
{
    public class BookService : EFAdapterBase<Book>, IBookService
    {
        public BookService(DbContext Context) : base(Context)
        {
        }

        public bool exists(string id)
        {
            return context.Set<Book>().Count(e => e._id == id) > 0;
        }

        public IEnumerable<Book> suggestions()
        {
            return context.Set<Book>().Where(o => o.enabled).OrderByDescending(o => o.created).Skip(0).Take(10);
        }

        public IEnumerable<Book> search(int page, int limit, Func<Book, bool> where)
        {
            page--;
            return context.Set<Book>().Where(o => o.enabled).OrderByDescending(o => o.created).Where(where).Skip(page * limit).Take(limit);
        }

        public IEnumerable<Book> searchByYear(int page, int limit, Func<Book, bool> where)
        {
            page--;
            return context.Set<Book>().Where(where).OrderByDescending(o => o.created).Skip(page * limit).Take(limit);
        }
    }
}
