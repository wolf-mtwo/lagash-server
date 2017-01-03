using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wargos.Core.EntityFramework;
using Wargos.Lagash.Entities;
using Wargos.Lagash.Interfaces;

namespace Wargos.Lagash.Services
{
    public class PersonService : EFAdapterBase<Person>, IPersonService
    {
        public PersonService()
        {
        }
    }
}
