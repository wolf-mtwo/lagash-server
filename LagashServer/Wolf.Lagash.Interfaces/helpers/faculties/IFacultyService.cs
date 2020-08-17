using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.helper.faculties;

namespace Wolf.Lagash.Interfaces.helpers.faculties
{
    public interface IFacultyService : IAdapterBase<Faculty>
    {
        bool exists(string id);
    }
}
