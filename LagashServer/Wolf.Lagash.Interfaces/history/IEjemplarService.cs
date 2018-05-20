using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.history;

namespace Wolf.Lagash.Interfaces.history
{
    public interface IEjemplarService : IAdapterBase<Ejemplar>
    {
        bool exists(String id);
    }
}
