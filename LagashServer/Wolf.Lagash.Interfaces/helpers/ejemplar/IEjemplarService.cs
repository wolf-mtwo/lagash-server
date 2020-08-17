using System.Collections.Generic;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.helper.ejemplar;

namespace Wolf.Lagash.Interfaces.helpers.ejemplar
{
    public interface IEjemplarService : IAdapterBase<Ejemplar>
    {
        bool exists(string id);
        IEnumerable<Ejemplar> select(int start, int end);
        Ejemplar next();
    }
}
