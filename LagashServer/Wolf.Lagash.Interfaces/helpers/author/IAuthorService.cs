using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.helper.author;

namespace Wolf.Lagash.Interfaces.helpers.author
{
    public interface IAuthorService : IAdapterBase<Author>
    {
        bool exists(string id);
    }
}
