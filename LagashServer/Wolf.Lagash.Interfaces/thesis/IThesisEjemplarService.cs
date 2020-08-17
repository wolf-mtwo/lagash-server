using System;
using System.Collections.Generic;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.thesis;

namespace Wolf.Lagash.Interfaces
{
    public interface IThesisEjemplarService : IAdapterBase<ThesisEjemplar>
    {
        bool exists(String id);
        IEnumerable<ThesisEjemplar> select(int start, int end);
        ThesisEjemplar next();
    }
}
