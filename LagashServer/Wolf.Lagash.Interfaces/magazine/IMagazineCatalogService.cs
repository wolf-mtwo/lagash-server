using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.magazine;

namespace Wolf.Lagash.Interfaces.magazine
{
    public interface IMagazineCatalogService : IAdapterBase<MagazineCatalog>
    {
        bool exists(string id);
    }
}
