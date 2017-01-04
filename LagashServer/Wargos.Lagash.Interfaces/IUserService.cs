using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wargos.Core.Interfaces;
using Wargos.Lagash.Entities;

namespace Wargos.Lagash.Interfaces
{
    public interface IUserService : IAdapterBase<User>
    {
        bool userExists(int id);
        void login(string username, string password);
    }
}
