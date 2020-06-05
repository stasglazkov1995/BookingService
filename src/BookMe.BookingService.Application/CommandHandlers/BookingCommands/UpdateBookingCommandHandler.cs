using System;
using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Commands.BookingCommands;
using BookMe.BookingService.Domain;
using MediatR;

namespace BookMe.BookingService.Application.CommandHandlers.BookingCommands
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, Booking>
    {
        public UpdateBookingCommandHandler()
        {
        }

        public Task<Booking> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
