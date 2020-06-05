using System;
using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Commands.BookingCommands;
using MediatR;

namespace BookMe.BookingService.Application.CommandHandlers.BookingCommands
{
    public class RejectBookingCommandHandler : IRequestHandler<RejectBookingCommand, bool>
    {
        public RejectBookingCommandHandler()
        {
        }

        public Task<bool> Handle(RejectBookingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
