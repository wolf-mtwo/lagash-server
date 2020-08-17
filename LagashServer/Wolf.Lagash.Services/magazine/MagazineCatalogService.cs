using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.magazine;
using Wolf.Lagash.Interfaces.magazine;

namespace Wolf.Lagash.Services.magazine
{
    public class MagazineCatalogService : EFAdapterBase<MagazineCatalog>, IMagazineCatalogService
    {
        public MagazineCatalogService(DbContext Context) : base(Context)
        {
        }

        public bool exists(string id)
        {
            return context.Set<MagazineCatalog>().Count(e => e._id == id) > 0;
        }
    }
}
