using System;
using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Commands.EventCommands;
using BookMe.BookingService.Data.Repositories.Abstractions;
using BookMe.BookingService.Domain;
using MediatR;

namespace BookMe.BookingService.Application.CommandHandlers.EventCommands
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Event>
    {
        private readonly IGeneralRepository<Event> _events;

        public CreateEventCommandHandler(IGeneralRepository<Event> events)
        {
            _events = events;
        }

        public async Task<Event> Handle(CreateEventCommand command, CancellationToken cancellationToken)
        {
            //TODO: create event number generator
            var eventNumber = Guid.NewGuid().ToString().Substring(0, 8);
            var @event = new Event(command.UserId, eventNumber)
            {
                Name = command.Name,
                Description = command.Description,
                LineOfBusiness = command.LineOfBusiness
            };

            await _events.AddAsync(@event);
            await _events.SaveAsync();

            return @event;
        }
    }
}
