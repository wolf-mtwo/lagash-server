﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Entities.booking;
using Wolf.Lagash.Entities.books;

namespace Wolf.Lagash.Interfaces
{
    public interface IBookingService : IAdapterBase<Booking>
    {
        bool exists(String id);
    }
}
