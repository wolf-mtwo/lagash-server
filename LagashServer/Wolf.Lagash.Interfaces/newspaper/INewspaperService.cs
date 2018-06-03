using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Entities.books;
using Wolf.Lagash.Entities.newspaper;

namespace Wolf.Lagash.Interfaces
{
    public interface INewspaperService : IAdapterBase<Newspaper>
    {
        bool exists(String id);
        IEnumerable<Newspaper> search(int page, int limit, Func<Newspaper, bool> where);
    }
}
