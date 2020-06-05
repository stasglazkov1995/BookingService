using System;
using MediatR;

namespace BookMe.BookingService.Application.Events.EventEvents
{
    public class EventDeactivatedEvent : INotification
    {
        public Guid Id { get; }

        public EventDeactivatedEvent(Guid id)
        {
            Id = id;
        }
    }
}
