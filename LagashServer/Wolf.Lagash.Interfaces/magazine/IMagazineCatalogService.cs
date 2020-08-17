using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Entities.magazine;

namespace Wolf.Lagash.Interfaces
{
    public interface IMagazineCatalogService : IAdapterBase<MagazineCatalog>
    {
        bool exists(String id);
    }
}
