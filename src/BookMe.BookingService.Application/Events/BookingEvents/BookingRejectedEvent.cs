using System;
using MediatR;

namespace BookMe.BookingService.Application.Events.BookingEvents
{
    public class BookingRejectedEvent : INotification
    {
        public BookingRejectedEvent()
        {
        }
    }
}
