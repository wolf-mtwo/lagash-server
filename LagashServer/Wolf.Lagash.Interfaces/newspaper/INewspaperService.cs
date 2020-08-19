using System;
using System.Collections.Generic;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.newspaper;

namespace Wolf.Lagash.Interfaces.newspaper
{
    public interface INewspaperService : IAdapterBase<Newspaper>
    {
        bool exists(string id);
        IEnumerable<Newspaper> search(int page, int limit, Func<Newspaper, bool> where);
    }
}
