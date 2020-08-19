using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.helper.faculties;

namespace Wolf.Lagash.Interfaces.helpers.faculties
{
    public interface ICarrerService : IAdapterBase<Carrer>
    {
        bool exists(string id);
    }
}
