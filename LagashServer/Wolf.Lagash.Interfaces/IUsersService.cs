using System;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities;

namespace Wolf.Lagash.Interfaces
{
    public interface IUsersService : IAdapterBase<User>
    {
        bool userExists(string id);
        User login(string email, string password);
        User FindByEmail(String email);
        User CreateUser(User item);
    }
}
