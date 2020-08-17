using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.helper.tutor;

namespace Wolf.Lagash.Interfaces.helpers.tutor
{
    public interface ITutorService : IAdapterBase<Tutor>
    {
        bool exists(string id);
    }
}
