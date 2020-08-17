using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.helper.reader;
using Wolf.Lagash.Interfaces.helpers.reader;

namespace Wolf.Lagash.Services.helpers.reader
{
    public class ReaderService : EFAdapterBase<Reader>, IReaderService
    {
        public ReaderService(DbContext Context) : base(Context)
        {
        }

        public bool exists(string id)
        {
            return context.Set<Reader>().Count(e => e._id == id) > 0;
        }
    }
}
