using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.helper.editorial;

namespace Wolf.Lagash.Interfaces.helpers.editorial
{
    public interface IEditorialMapService : IAdapterBase<EditorialMap>
    {
        bool exists(string id);
    }
}
