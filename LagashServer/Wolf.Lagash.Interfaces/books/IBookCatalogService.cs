using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.books;

namespace Wolf.Lagash.Interfaces.books
{
    public interface IBookCatalogService : IAdapterBase<BookCatalog>
    {
        bool exists(string id);
    }
}
