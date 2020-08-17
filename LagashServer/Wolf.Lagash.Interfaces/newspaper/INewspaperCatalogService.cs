using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.newspaper;

namespace Wolf.Lagash.Interfaces.newspaper
{
    public interface INewspaperCatalogService : IAdapterBase<NewspaperCatalog>
    {
        bool exists(string id);
    }
}
