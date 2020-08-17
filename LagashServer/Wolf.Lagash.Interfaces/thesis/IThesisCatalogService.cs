using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.thesis;

namespace Wolf.Lagash.Interfaces.thesis
{
    public interface IThesisCatalogService : IAdapterBase<ThesisCatalog>
    {
        bool exists(string id);
    }
}
