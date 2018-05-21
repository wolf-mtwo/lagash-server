using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.helper.ejemplar;
using Wolf.Lagash.Interfaces.helper.ejemplar;

namespace Wolf.Lagash.Services.helper.ejemplar
{
    public class EjemplarService : EFAdapterBase<Ejemplar>, IEjemplarService
    {
        public EjemplarService(DbContext Context) : base(Context)
        {
        }

        public bool exists(String id)
        {
            return context.Set<Ejemplar>().Count(e => e._id == id) > 0;
        }
    }
}
