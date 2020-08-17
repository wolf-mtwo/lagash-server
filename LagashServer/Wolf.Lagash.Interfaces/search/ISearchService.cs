using System;
using System.Collections.Generic;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.search;

namespace Wolf.Lagash.Interfaces
{
    public interface ISearchService : IAdapterBase<Search>
    {
        List<Search> SearchItems(string typeSearch, bool isAll, string filter, string listAuthor, string listEditorial, string listYear, int page, int limit);
    }
}
