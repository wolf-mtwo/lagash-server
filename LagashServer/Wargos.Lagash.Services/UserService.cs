using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wargos.Core.EntityFramework;
using Wargos.Lagash.Entities;
using Wargos.Lagash.Interfaces;

namespace Wargos.Lagash.Services
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
