using System;
using MediatR;

namespace BookMe.BookingService.Application.Commands.EventCommands
{
    public class DeleteEventCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public DeleteEventCommand(Guid id)
        {
            Id = id;
        }
    }
}
