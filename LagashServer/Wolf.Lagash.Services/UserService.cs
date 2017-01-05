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
    public class UserService : EFAdapterBase<User>, IUserService
    {
        public UserService(DbContext Context) : base(Context)
        {
        }

        public void login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool userExists(int id)
        {
            return context.Set<User>().Count(e => e._id == id) > 0;
        }
    }
}
