using System;
using MediatR;

namespace BookMe.BookingService.Application.Commands.BookingCommands
{
    public class CancelBookingCommand : IRequest<bool>
    {
        public CancelBookingCommand()
        {
        }
    }
}
