using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.thesis;
using Wolf.Lagash.Interfaces.thesis;

namespace Wolf.Lagash.Services.thesis
{
    public class ThesisEjemplarService : EFAdapterBase<ThesisEjemplar>, IThesisEjemplarService
    {
        public ThesisEjemplarService(DbContext Context) : base(Context)
        {
        }

        public bool exists(string id)
        {
            return context.Set<ThesisEjemplar>().Count(e => e._id == id) > 0;
        }

        public IEnumerable<ThesisEjemplar> select(int start, int end)
        {
            return context.Set<ThesisEjemplar>().OrderByDescending(o => o.inventory).Where(o => o.inventory <= start && o.inventory >= end);
        }

        public ThesisEjemplar next()
        {
            return context.Set<ThesisEjemplar>().OrderByDescending(o => o.inventory).FirstOrDefault();
        }
    }
}
