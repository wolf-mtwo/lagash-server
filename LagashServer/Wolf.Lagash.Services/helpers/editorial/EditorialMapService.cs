using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.helper.editorial;
using Wolf.Lagash.Interfaces.helpers.editorial;

namespace Wolf.Lagash.Services.helpers.editorial
{
    public class EditorialMapService : EFAdapterBase<EditorialMap>, IEditorialMapService
    {
        public EditorialMapService(DbContext Context) : base(Context)
        {
        }

        public bool exists(string id)
        {
            return context.Set<EditorialMap>().Count(e => e._id == id) > 0;
        }
    }
}
