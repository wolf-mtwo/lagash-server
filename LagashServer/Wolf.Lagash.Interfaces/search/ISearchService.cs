using System.Collections.Generic;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.search;

namespace Wolf.Lagash.Interfaces.search
{
    public interface ISearchService : IAdapterBase<Search>
    {
        List<Search> SearchItems(string typeSearch, bool isAll, string filter, string listAuthor, string listEditorial, string listYear, string listDestriptor, string listIndexer, int page, int limit);
    }
}
