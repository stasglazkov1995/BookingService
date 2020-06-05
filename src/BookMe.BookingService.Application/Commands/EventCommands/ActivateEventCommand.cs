using System;
using MediatR;

namespace BookMe.BookingService.Application.Commands.EventCommands
{
    public class ActivateEventCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public ActivateEventCommand(Guid id)
        {
            Id = id;
        }
    }
}
