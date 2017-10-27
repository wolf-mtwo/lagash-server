using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.map;

namespace Wolf.Lagash.Interfaces.map
{
    public interface IAuthorMapService : IAdapterBase<AuthorMap>
    {
        bool exists(int id);
    }
}
