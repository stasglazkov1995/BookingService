using System;
using MediatR;

namespace BookMe.BookingService.Application.Events.EventEvents
{
    public class EventUpdatedEvent : INotification
    {
        public Guid Id { get; }

        public EventUpdatedEvent(Guid id)
        {
            Id = id;
        }
    }
}
