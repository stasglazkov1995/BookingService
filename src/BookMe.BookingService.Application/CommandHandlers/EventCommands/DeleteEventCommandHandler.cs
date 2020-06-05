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
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, bool>
    {
        private readonly IGeneralRepository<Event> _events;
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public DeleteEventCommandHandler(
            IGeneralRepository<Event> events,
            IMediator mediator,
            ILogger<DeleteEventCommandHandler> logger)
        {
            _events = events;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
        {
            var @event = await _events.GetAsync(command.Id);
            if (@event is null)
            {
                throw new Exception($"Event with id {command.Id} does not exist");
            }

            if (@event.IsDeleted)
            {
                _logger.LogInformation("Deletion of event: {eventId} was skipped as it's already deleted", @event.Id);
                return true;
            }

            @event.Delete();

            _events.Edit(@event);
            await _events.SaveAsync();

            await _mediator.Publish(new EventDeletedEvent(@event.Id));

            return true;
        }
    }
}
