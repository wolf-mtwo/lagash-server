using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.map;

namespace Wolf.Lagash.Interfaces.map
{
    public interface IUsersMapService : IAdapterBase<UserMap>
    {
        bool exists(int id);
    }
}
