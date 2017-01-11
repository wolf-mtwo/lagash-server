using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities;

namespace Wolf.Lagash.Interfaces
{
    public interface IUserService : IAdapterBase<User>
    {
        bool userExists(int id);
        void login(string username, string password);
        User FindByEmail(String email);
        void CreateUser(User item);
    }
}
