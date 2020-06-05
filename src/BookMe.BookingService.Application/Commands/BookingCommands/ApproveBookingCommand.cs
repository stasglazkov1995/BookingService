using System;
using MediatR;

namespace BookMe.BookingService.Application.Commands.BookingCommands
{
    public class ApproveBookingCommand : IRequest<bool>
    {
        public Guid BookingId { get; }
        public ApproveBookingCommand(Guid bookingId)
        {
            BookingId = bookingId;
        }

    }
}
