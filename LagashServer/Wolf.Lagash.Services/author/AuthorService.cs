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
    public class AuthorService : EFAdapterBase<Author>, IAuthorService
    {
        public AuthorService(DbContext Context) : base(Context)
        {
        }

        public bool exists(String id)
        {
            return context.Set<Author>().Count(e => e._id == id) > 0;
        }
    }
}
