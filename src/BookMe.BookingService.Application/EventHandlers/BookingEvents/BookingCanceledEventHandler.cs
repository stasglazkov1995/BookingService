using System;
using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Events.BookingEvents;
using MediatR;

namespace BookMe.BookingService.Application.EventHandlers.BookingEvents
{
    public class BookingCanceledEventHandler : INotificationHandler<BookingCanceledEvent>
    {
        public BookingCanceledEventHandler()
        {
        }

        public Task Handle(BookingCanceledEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
