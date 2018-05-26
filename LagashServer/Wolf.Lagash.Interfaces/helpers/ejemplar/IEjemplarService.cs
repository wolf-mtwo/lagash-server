using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.helper.ejemplar;

namespace Wolf.Lagash.Interfaces.helper.ejemplar
{
    public interface IEjemplarService : IAdapterBase<Ejemplar>
    {
        bool exists(String id);
        IEnumerable<Ejemplar> select(int start, int end);
        Ejemplar next();
    }
}
