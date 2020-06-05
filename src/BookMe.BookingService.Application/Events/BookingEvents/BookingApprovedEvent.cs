using System;
using MediatR;

namespace BookMe.BookingService.Application.Events.BookingEvents
{
    public class BookingApprovedEvent : INotification
    {
        public Guid BookingId { get; }

        public BookingApprovedEvent(Guid bookingId)
        {
            BookingId = bookingId;
        }
    }
}
