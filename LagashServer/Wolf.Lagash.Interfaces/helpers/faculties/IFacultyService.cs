using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Entities.map;

namespace Wolf.Lagash.Interfaces.map
{
    public interface IFacultyService : IAdapterBase<Faculty>
    {
        bool exists(String id);
    }
}
