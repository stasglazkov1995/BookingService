using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Events.EventEvents;
using MediatR;

namespace BookMe.BookingService.Application.EventHandlers.EventEvents
{
    public class SendNotificationOnEventUpdatedEventHandler : INotificationHandler<EventUpdatedEvent>
    {
        public SendNotificationOnEventUpdatedEventHandler()
        {
        }

        public async Task Handle(EventUpdatedEvent notification, CancellationToken cancellationToken)
        {
            //TODO: do something
        }
    }
}
