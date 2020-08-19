using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.helper.author;
using Wolf.Lagash.Interfaces.helpers.author;

namespace Wolf.Lagash.Services.helpers.author
{
    public class AuthorService : EFAdapterBase<Author>, IAuthorService
    {
        public AuthorService(DbContext Context) : base(Context)
        {
        }

        public bool exists(string id)
        {
            return context.Set<Author>().Count(e => e._id == id) > 0;
        }
    }
}
