using System;
using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.booking;
using Wolf.Lagash.Interfaces.booking;

namespace Wolf.Lagash.Services.booking
{
    public class BookingService : EFAdapterBase<Booking>, IBookingService
    {
        public BookingService(DbContext Context) : base(Context)
        {
        }

        public bool exists(String id)
        {
            return context.Set<Booking>().Count(e => e._id == id) > 0;
        }
    }
}
