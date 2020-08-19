using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.helper.reader;

namespace Wolf.Lagash.Interfaces.helpers.reader
{
    public interface IReaderService : IAdapterBase<Reader>
    {
        bool exists(string id);
    }
}
