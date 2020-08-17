using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.map;
using Wolf.Lagash.Interfaces.map;

namespace Wolf.Lagash.Services
{
    public class UsersMapService : EFAdapterBase<UserMap>, IUsersMapService
    {
        public UsersMapService(DbContext Context) : base(Context)
        {
        }

        public bool exists(int id)
        {
            return context.Set<UserMap>().Count(e => e._id == id) > 0;
        }
    }
}
