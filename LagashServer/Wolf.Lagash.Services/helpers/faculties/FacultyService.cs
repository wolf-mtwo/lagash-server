using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.helper.faculties;
using Wolf.Lagash.Interfaces.map;

namespace Wolf.Lagash.Services
{
    public class FacultyService : EFAdapterBase<Faculty>, IFacultyService
    {
        public FacultyService(DbContext Context) : base(Context)
        {
        }

        public bool exists(String id)
        {
            return context.Set<Faculty>().Count(e => e._id == id) > 0;
        }
    }
}
