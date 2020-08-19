using System;
using System.Collections.Generic;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.books;

namespace Wolf.Lagash.Interfaces.books
{
    public interface IBookService : IAdapterBase<Book>
    {
        bool exists(string id);
        IEnumerable<Book> search(int page, int limit, Func<Book, bool> where);
    }
}
