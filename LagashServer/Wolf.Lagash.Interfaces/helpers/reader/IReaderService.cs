using System;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Entities.helper.reader;

namespace Wolf.Lagash.Interfaces
{
    public interface IReaderService : IAdapterBase<Reader>
    {
        bool exists(String id);
    }
}
