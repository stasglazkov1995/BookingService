using BookMe.BookingService.Api.Models.Bookings.BookingEnum;
using BookMe.BookingService.Api.Models.Events;
using System;

namespace BookMe.BookingService.Api.Models.Bookings
{
    public class BookingModel
    {
        public Guid EventId { get; set; }

        public EventModel Event { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime BookingDate { get; set; }

        public BookingStatus BookingStatus { get; set; }
    }
}
