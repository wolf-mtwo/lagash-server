using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.helper.editorial;

namespace Wolf.Lagash.Interfaces.helpers.editorial
{
    public interface IEditorialService : IAdapterBase<Editorial>
    {
        bool exists(string id);
    }
}
