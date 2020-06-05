using System;
using BookMe.BookingService.Domain;
using MediatR;

namespace BookMe.BookingService.Application.Commands.BookingCommands
{
    public class UpdateBookingCommand : IRequest<Booking>
    {
        public UpdateBookingCommand()
        {
        }
    }
}
