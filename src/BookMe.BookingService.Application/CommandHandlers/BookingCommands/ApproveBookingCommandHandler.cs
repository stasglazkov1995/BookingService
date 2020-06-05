using System;
using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Commands.BookingCommands;
using BookMe.BookingService.Application.Events.BookingEvents;
using BookMe.BookingService.Data.Repositories.Abstractions;
using BookMe.BookingService.Domain;
using MediatR;

namespace BookMe.BookingService.Application.CommandHandlers.BookingCommands
{
    public class ApproveBookingCommandHandler : IRequestHandler<ApproveBookingCommand, bool>
    {
        private readonly IGeneralRepository<Booking> _booking;
        private readonly IMediator _mediator;
        public ApproveBookingCommandHandler(IMediator mediator, IGeneralRepository<Booking> booking)
        {
            _booking = booking;
            _mediator = mediator;
        }


        public async Task<bool> Handle(ApproveBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _booking.GetAsync(request.BookingId);

            if (booking is null)
            {
                throw new Exception($"Booking with id {request.BookingId} does not exist");
            }

            booking.ApproveBooking(booking.BookingStatus);
            _booking.Edit(booking);

            await _booking.SaveAsync();
            await _mediator.Publish(new BookingApprovedEvent(booking.Id));
            return true;


        }
    }
}
