using System;
using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Events.BookingEvents;
using MediatR;

namespace BookMe.BookingService.Application.EventHandlers.BookingEvents
{
    public class BookingApprovedEventHandler : INotificationHandler<BookingApprovedEvent>
    {
        public BookingApprovedEventHandler()
        {
        }

        public Task Handle(BookingApprovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
