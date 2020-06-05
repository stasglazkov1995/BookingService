using System;
using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Events.BookingEvents;
using MediatR;

namespace BookMe.BookingService.Application.EventHandlers.BookingEvents
{
    public class BookingPlacedEventHandler : INotificationHandler<BookingPlacedEvent>
    {
        public BookingPlacedEventHandler()
        {
        }

        public Task Handle(BookingPlacedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
