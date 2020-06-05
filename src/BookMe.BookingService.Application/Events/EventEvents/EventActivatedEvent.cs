using System;
using MediatR;

namespace BookMe.BookingService.Application.Events.EventEvents
{
    public class EventActivatedEvent : INotification
    {
        public Guid Id { get; }

        public EventActivatedEvent(Guid id)
        {
            Id = id;
        }
    }
}
