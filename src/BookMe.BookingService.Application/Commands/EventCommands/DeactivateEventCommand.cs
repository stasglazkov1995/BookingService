using System;
using MediatR;

namespace BookMe.BookingService.Application.Commands.EventCommands
{
    public class DeactivateEventCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public DeactivateEventCommand(Guid id)
        {
            Id = id;
        }
    }
}
