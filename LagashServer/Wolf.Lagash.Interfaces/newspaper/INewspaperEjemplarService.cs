using System;
using System.Collections.Generic;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.newspaper;

namespace Wolf.Lagash.Interfaces
{
    public interface INewspaperEjemplarService : IAdapterBase<NewspaperEjemplar>
    {
        bool exists(String id);
        IEnumerable<NewspaperEjemplar> select(int start, int end);
        NewspaperEjemplar next();
    }
}
