using System;
using MediatR;

namespace BookMe.BookingService.Application.Events.EventEvents
{
    public class EventDeletedEvent : INotification
    {
        public Guid Id { get; }

        public EventDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
