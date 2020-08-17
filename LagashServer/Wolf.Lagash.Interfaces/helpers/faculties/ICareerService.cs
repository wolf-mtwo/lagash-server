using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Entities.helper.faculties;

namespace Wolf.Lagash.Interfaces
{
    public interface ICarrerService : IAdapterBase<Carrer>
    {
        bool exists(String id);
    }
}
