using System;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.newspaper;

namespace Wolf.Lagash.Interfaces
{
    public interface INewspaperCatalogService : IAdapterBase<NewspaperCatalog>
    {
        bool exists(String id);
    }
}
