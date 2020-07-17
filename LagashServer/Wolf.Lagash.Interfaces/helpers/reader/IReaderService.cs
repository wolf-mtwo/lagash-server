using System;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities;

namespace Wolf.Lagash.Interfaces
{
    public interface IReaderService : IAdapterBase<Reader>
    {
        bool exists(String id);
    }
}
