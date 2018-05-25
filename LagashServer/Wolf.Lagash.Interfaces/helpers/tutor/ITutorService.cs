using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Entities.tutor;

namespace Wolf.Lagash.Interfaces
{
    public interface ITutorService : IAdapterBase<Tutor>
    {
        bool exists(String id);
    }
}
