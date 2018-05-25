using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Interfaces;

namespace Wolf.Lagash.Services
{
    public class CarrerService : EFAdapterBase<Carrer>, ICarrerService
    {
        public CarrerService(DbContext Context) : base(Context)
        {
        }

        public bool exists(String id)
        {
            return context.Set<Carrer>().Count(e => e._id == id) > 0;
        }
    }
}
