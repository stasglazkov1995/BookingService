using System;
using BookMe.BookingService.Domain;
using MediatR;

namespace BookMe.BookingService.Application.Commands.EventCommands
{
    public class UpdateEventCommand : IRequest<Event>
    {
        public Guid Id { get; }

        public string Name { get; }

        public string Description { get; }

        public string LineOfBusiness { get; }

        public UpdateEventCommand(
            Guid id,
            string name,
            string description,
            string lineOfBusiness)
        {
            Id = id;
            Name = name;
            Description = description;
            LineOfBusiness = lineOfBusiness;
        }
    }
}
