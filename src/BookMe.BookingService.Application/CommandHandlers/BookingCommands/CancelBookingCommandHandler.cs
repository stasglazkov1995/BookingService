using System;
using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Commands.BookingCommands;
using MediatR;

namespace BookMe.BookingService.Application.CommandHandlers.BookingCommands
{
    public class CancelBookingCommandHandler : IRequestHandler<CancelBookingCommand, bool>
    {
        public CancelBookingCommandHandler()
        {
        }

        public Task<bool> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
