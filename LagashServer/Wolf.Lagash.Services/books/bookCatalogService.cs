using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.books;
using Wolf.Lagash.Interfaces.books;

namespace Wolf.Lagash.Services.books
{
    public class BookCatalogService : EFAdapterBase<BookCatalog>, IBookCatalogService
    {
        public BookCatalogService(DbContext Context) : base(Context)
        {
        }

        public bool exists(string id)
        {
            return context.Set<BookCatalog>().Count(e => e._id == id) > 0;
        }
    }
}
