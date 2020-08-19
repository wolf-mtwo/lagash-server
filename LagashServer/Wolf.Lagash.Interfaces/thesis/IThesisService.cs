using System;
using System.Collections.Generic;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.thesis;

namespace Wolf.Lagash.Interfaces.thesis
{
    public interface IThesisService : IAdapterBase<Thesis>
    {
        bool exists(string id);
        IEnumerable<Thesis> search(int page, int limit, Func<Thesis, bool> where);
    }
}
