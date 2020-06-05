using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Events.EventEvents;
using MediatR;

namespace BookMe.BookingService.Application.EventHandlers.EventEvents
{
    public class SendNotificationOnEventDeletedEventHandler : INotificationHandler<EventDeletedEvent>
    {
        public SendNotificationOnEventDeletedEventHandler()
        {
        }

        public async Task Handle(EventDeletedEvent notification, CancellationToken cancellationToken)
        {
            //TODO: do something
        }
    }
}
