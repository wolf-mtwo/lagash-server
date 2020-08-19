using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.newspaper;
using Wolf.Lagash.Interfaces.newspaper;

namespace Wolf.Lagash.Services.newspaper
{
    public class NewspaperCatalogService : EFAdapterBase<NewspaperCatalog>, INewspaperCatalogService
    {
        public NewspaperCatalogService(DbContext Context) : base(Context)
        {
        }

        public bool exists(string id)
        {
            return context.Set<NewspaperCatalog>().Count(e => e._id == id) > 0;
        }
    }
}
