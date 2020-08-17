using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.booking;

namespace Wolf.Lagash.Interfaces.booking
{
    public interface IBookingService : IAdapterBase<Booking>
    {
        bool exists(string id);
    }
}
