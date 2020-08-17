using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.helper.author;

namespace Wolf.Lagash.Interfaces.helpers.author
{
    public interface IAuthorMapService : IAdapterBase<AuthorMap>
    {
        bool exists(string id);
    }
}
