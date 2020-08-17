using System;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.thesis;

namespace Wolf.Lagash.Interfaces
{
    public interface IThesisCatalogService : IAdapterBase<ThesisCatalog>
    {
        bool exists(String id);
    }
}
