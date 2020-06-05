using System;
using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Commands.EventCommands;
using BookMe.BookingService.Application.Events.EventEvents;
using BookMe.BookingService.Data.Repositories.Abstractions;
using BookMe.BookingService.Domain;
using MediatR;

namespace BookMe.BookingService.Application.CommandHandlers.EventCommands
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Event>
    {
        private readonly IGeneralRepository<Event> _events;
        private readonly IMediator _mediator;

        public UpdateEventCommandHandler(
            IGeneralRepository<Event> events,
            IMediator mediator)
        {
            _events = events;
            _mediator = mediator;
        }

        public async Task<Event> Handle(UpdateEventCommand command, CancellationToken cancellationToken)
        {
            var @event = await _events.GetAsync(command.Id);
            if (@event is null)
            {
                throw new Exception($"Event with id {command.Id} does not exist");
            }

            @event.Name = command.Name;
            @event.Description = command.Description;
            @event.LineOfBusiness = command.LineOfBusiness;

            _events.Edit(@event);
            await _events.SaveAsync();

            await _mediator.Publish(new EventUpdatedEvent(@event.Id));

            return @event;
        }
    }
}
