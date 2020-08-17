using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Entities.helper.author;

namespace Wolf.Lagash.Interfaces
{
    public interface IAuthorService : IAdapterBase<Author>
    {
        bool exists(String id);
    }
}
