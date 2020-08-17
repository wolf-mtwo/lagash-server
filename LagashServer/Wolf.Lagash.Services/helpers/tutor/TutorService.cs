using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.helper.tutor;
using Wolf.Lagash.Interfaces.helpers.tutor;

namespace Wolf.Lagash.Services.helpers.tutor
{
    public class TutorService : EFAdapterBase<Tutor>, ITutorService
    {
        public TutorService(DbContext Context) : base(Context)
        {
        }

        public bool exists(string id)
        {
            return context.Set<Tutor>().Count(e => e._id == id) > 0;
        }
    }
}
