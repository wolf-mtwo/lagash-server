using System.Collections.Generic;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.books;

namespace Wolf.Lagash.Interfaces.books
{
    public interface IBookEjemplarService : IAdapterBase<BookEjemplar>
    {
        bool exists(string id);
        IEnumerable<BookEjemplar> select(int start, int end);
        BookEjemplar next();
    }
}
