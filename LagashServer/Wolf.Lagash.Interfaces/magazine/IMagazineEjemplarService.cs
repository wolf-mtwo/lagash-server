using System.Collections.Generic;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.magazine;

namespace Wolf.Lagash.Interfaces.magazine
{
    public interface IMagazineEjemplarService : IAdapterBase<MagazineEjemplar>
    {
        bool exists(string id);
        IEnumerable<MagazineEjemplar> select(int start, int end);
        MagazineEjemplar next();
    }
}
