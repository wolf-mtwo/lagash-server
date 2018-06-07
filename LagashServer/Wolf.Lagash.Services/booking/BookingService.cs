using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Entities.books;
using Wolf.Lagash.Interfaces;

namespace Wolf.Lagash.Services
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
