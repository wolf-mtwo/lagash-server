using System;
using System.Collections.Generic;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.magazine;

namespace Wolf.Lagash.Interfaces.magazine
{
    public interface IMagazineService : IAdapterBase<Magazine>
    {
        bool exists(string id);
        IEnumerable<Magazine> search(int page, int limit, Func<Magazine, bool> where);
    }
}
