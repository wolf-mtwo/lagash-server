using System;
using System.Collections.Generic;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.magazine;

namespace Wolf.Lagash.Interfaces
{
    public interface IMagazineService : IAdapterBase<Magazine>
    {
        bool exists(String id);
        IEnumerable<Magazine> search(int page, int limit, Func<Magazine, bool> where);
    }
}
