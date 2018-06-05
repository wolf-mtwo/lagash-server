using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities;

namespace Wolf.Lagash.Interfaces
{
    public interface INewspaperEjemplarService : IAdapterBase<NewspaperEjemplar>
    {
        bool exists(String id);
        IEnumerable<NewspaperEjemplar> select(int start, int end);
        NewspaperEjemplar next();
    }
}
