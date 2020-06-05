using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Events.EventEvents;
using MediatR;

namespace BookMe.BookingService.Application.EventHandlers.EventEvents
{
    public class SendNotificationOnEventActivatedEventHandler : INotificationHandler<EventActivatedEvent>
    {
        public SendNotificationOnEventActivatedEventHandler()
        {
        }

        public async Task Handle(EventActivatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO: do something
        }
    }
}
