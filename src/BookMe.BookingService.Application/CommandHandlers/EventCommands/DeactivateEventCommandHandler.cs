using System;
using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Commands.EventCommands;
using BookMe.BookingService.Application.Events.EventEvents;
using BookMe.BookingService.Data.Repositories.Abstractions;
using BookMe.BookingService.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookMe.BookingService.Application.CommandHandlers.EventCommands
{
    public class DeactivateEventCommandHandler : IRequestHandler<DeactivateEventCommand, bool>
    {
        private readonly IGeneralRepository<Event> _events;
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public DeactivateEventCommandHandler(
            IGeneralRepository<Event> events,
            IMediator mediator,
            ILogger<DeactivateEventCommandHandler> logger)
        {
            _events = events;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<bool> Handle(DeactivateEventCommand command, CancellationToken cancellationToken)
        {
            var @event = await _events.GetAsync(command.Id);
            if (@event is null)
            {
                throw new Exception($"Event with id {command.Id} does not exist");
            }

            if (!@event.IsActive)
            {
                _logger.LogInformation("Deactivation of event: {eventId} was skipped as it's already deactivated", @event.Id);
                return true;
            }

            @event.Deactivate();

            _events.Edit(@event);
            await _events.SaveAsync();

            await _mediator.Publish(new EventDeactivatedEvent(@event.Id));

            return true;
        }
    }
}
