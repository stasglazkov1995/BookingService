using System;
using MediatR;

namespace BookMe.BookingService.Application.Events.BookingEvents
{
    public class BookingPlacedEvent : INotification
    {
        public BookingPlacedEvent()
        {
        }
    }
}
