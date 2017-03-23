using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities;

namespace Wolf.Lagash.Interfaces
{
    public interface IEjemplaresService : IAdapterBase<Ejemplar>
    {
        bool exists(String id);
    }
}
