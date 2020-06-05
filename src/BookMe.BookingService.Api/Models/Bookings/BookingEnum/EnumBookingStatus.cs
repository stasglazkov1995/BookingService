using System;
using System.Collections.Generic;
using System.Text;

namespace BookMe.BookingService.Api.Models.Bookings.BookingEnum
{
    public enum BookingStatus
    {
        Placed = 1,
        Approved = 5,
        Rejected = 10,
        Canceled = 15
    }
}
