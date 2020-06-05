using System;
using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Events.BookingEvents;
using MediatR;

namespace BookMe.BookingService.Application.EventHandlers.BookingEvents
{
    public class BookingRejectedEventHandler : INotificationHandler<BookingRejectedEvent>
    {
        public BookingRejectedEventHandler()
        {
        }

        public Task Handle(BookingRejectedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
