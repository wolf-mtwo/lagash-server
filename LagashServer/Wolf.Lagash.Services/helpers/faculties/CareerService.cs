using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.helper.faculties;
using Wolf.Lagash.Interfaces.helpers.faculties;

namespace Wolf.Lagash.Services.helpers.faculties
{
    public class CarrerService : EFAdapterBase<Carrer>, ICarrerService
    {
        public CarrerService(DbContext Context) : base(Context)
        {
        }

        public bool exists(string id)
        {
            return context.Set<Carrer>().Count(e => e._id == id) > 0;
        }
    }
}
