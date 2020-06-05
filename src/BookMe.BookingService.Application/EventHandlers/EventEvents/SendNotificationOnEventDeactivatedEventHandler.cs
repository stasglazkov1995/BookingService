using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Events.EventEvents;
using MediatR;

namespace BookMe.BookingService.Application.EventHandlers.EventEvents
{
    public class SendNotificationOnEventDeactivatedEventHandler : INotificationHandler<EventDeactivatedEvent>
    {
        public SendNotificationOnEventDeactivatedEventHandler()
        {
        }

        public async Task Handle(EventDeactivatedEvent notification, CancellationToken cancellationToken)
        {
            //TODO: do something
        }
    }
}
