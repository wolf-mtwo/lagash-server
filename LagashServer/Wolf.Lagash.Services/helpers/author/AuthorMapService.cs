using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.helper.author;
using Wolf.Lagash.Interfaces.map;

namespace Wolf.Lagash.Services
{
    public class AuthorMapService : EFAdapterBase<AuthorMap>, IAuthorMapService
    {
        public AuthorMapService(DbContext Context) : base(Context)
        {
        }

        public bool exists(string id)
        {
            return context.Set<AuthorMap>().Count(e => e._id == id) > 0;
        }
    }
}
