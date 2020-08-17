using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.helper.editorial;
using Wolf.Lagash.Interfaces;

namespace Wolf.Lagash.Services
{
    public class EditorialService : EFAdapterBase<Editorial>, IEditorialService
    {
        public EditorialService(DbContext Context) : base(Context)
        {
        }

        public bool exists(String id)
        {
            return context.Set<Editorial>().Count(e => e._id == id) > 0;
        }
    }
}
