using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.books;
using Wolf.Lagash.Entities.thesis;
using Wolf.Lagash.Interfaces.thesis;

namespace Wolf.Lagash.Services.thesis
{
    public class ThesisCatalogService : EFAdapterBase<ThesisCatalog>, IThesisCatalogService
    {
        public ThesisCatalogService(DbContext Context) : base(Context)
        {
        }

        public bool exists(string id)
        {
            return context.Set<BookCatalog>().Count(e => e._id == id) > 0;
        }
    }
}
