using System.Collections.Generic;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.newspaper;

namespace Wolf.Lagash.Interfaces.newspaper
{
    public interface INewspaperEjemplarService : IAdapterBase<NewspaperEjemplar>
    {
        bool exists(string id);
        IEnumerable<NewspaperEjemplar> select(int start, int end);
        NewspaperEjemplar next();
    }
}
