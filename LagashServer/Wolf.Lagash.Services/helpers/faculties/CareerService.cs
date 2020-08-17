using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.helper.faculties;
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
