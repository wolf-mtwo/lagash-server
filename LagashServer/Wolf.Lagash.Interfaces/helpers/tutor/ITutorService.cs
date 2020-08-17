using System;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.helper.tutor;

namespace Wolf.Lagash.Interfaces
{
    public interface ITutorService : IAdapterBase<Tutor>
    {
        bool exists(String id);
    }
}
