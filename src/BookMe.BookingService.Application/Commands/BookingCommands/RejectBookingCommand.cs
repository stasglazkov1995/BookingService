using System;
using MediatR;

namespace BookMe.BookingService.Application.Commands.BookingCommands
{
    public class RejectBookingCommand : IRequest<bool>
    {
        public RejectBookingCommand()
        {
        }
    }
}
