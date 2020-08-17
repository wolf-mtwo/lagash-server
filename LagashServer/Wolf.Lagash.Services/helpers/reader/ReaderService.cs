using System;
using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.helper.reader;
using Wolf.Lagash.Interfaces;

namespace Wolf.Lagash.Services
{
    public class ReaderService : EFAdapterBase<Reader>, IReaderService
    {
        public ReaderService(DbContext Context) : base(Context)
        {
        }

        public bool exists(String id)
        {
            return context.Set<Reader>().Count(e => e._id == id) > 0;
        }
    }
}
