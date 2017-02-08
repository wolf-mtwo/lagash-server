using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities;

namespace Wolf.Lagash.Interfaces
{
    public interface IUsersService : IAdapterBase<User>
    {
        bool userExists(int id);
        User login(string email, string password);
        User FindByEmail(String email);
        void CreateUser(User item);
    }
}
