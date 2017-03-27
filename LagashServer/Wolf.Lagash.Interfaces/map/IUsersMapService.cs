using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.map;

namespace Wolf.Lagash.Interfaces.map
{
    public interface ILibrariesService : IAdapterBase<UserMap>
    {
        bool exists(int id);
    }
}
