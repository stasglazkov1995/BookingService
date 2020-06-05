using System;
using MediatR;

namespace BookMe.BookingService.Application.Events.BookingEvents
{
    public class BookingCanceledEvent : INotification
    {
        public BookingCanceledEvent()
        {
        }
    }
}
