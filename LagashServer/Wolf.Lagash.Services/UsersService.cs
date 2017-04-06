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
    public class UsersService : EFAdapterBase<User>, IUsersService
    {
        public UsersService(DbContext Context) : base(Context)
        {
        }

        public User login(string email, string password)
        {
            if (email == null) {
                throw new Exception("email is undefined");
            }
            if (password == null) {
                throw new Exception("password is undefined");
            }
            return FindOne(o => o.email == email && o.password == password);
        }

        public bool userExists(int id)
        {
            return context.Set<User>().Count(e => e._id == id) > 0;
        }

        public User FindByEmail(String email)
        {
            if (email == null) {
                throw new Exception("email is undefined");
            }
            return FindOne(o => o.email == email);
        }

        public User CreateUser(User item)
        {
            User user = FindByEmail(item.email);
            if (user != null) {
                throw new Exception("ya existe un usuario con el mismo email");
            }
            return Create(item);
        }
    }
}
