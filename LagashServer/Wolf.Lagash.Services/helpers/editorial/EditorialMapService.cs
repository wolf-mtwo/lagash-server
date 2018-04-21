using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Entities.map;
using Wolf.Lagash.Interfaces;
using Wolf.Lagash.Interfaces.map;

namespace Wolf.Lagash.Services
{
    public class EditorialMapService : EFAdapterBase<EditorialMap>, IEditorialMapService
    {
        public EditorialMapService(DbContext Context) : base(Context)
        {
        }

        public bool exists(String id)
        {
            return context.Set<EditorialMap>().Count(e => e._id == id) > 0;
        }
    }
}
