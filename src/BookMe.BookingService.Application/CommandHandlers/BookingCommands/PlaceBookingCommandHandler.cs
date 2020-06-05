using System;
using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Commands.BookingCommands;
using BookMe.BookingService.Data.Repositories.Abstractions;
using BookMe.BookingService.Domain;
using MediatR;

namespace BookMe.BookingService.Application.CommandHandlers.BookingCommands
{
    public class PlaceBookingCommandHandler : IRequestHandler<PlaceBookingCommand, Booking>
    {
        private readonly IGeneralRepository<Booking> _booking;
        private readonly IGeneralRepository<Event> _events;
        private readonly IMediator _mediator;
        public PlaceBookingCommandHandler(IGeneralRepository<Booking> booking, 
            IGeneralRepository<Event> events,
            IMediator mediator)
        {
            _booking = booking;
            _events = events;
            _mediator = mediator;
        }

        public async Task<Booking> Handle(PlaceBookingCommand request, CancellationToken cancellationToken)
        {
            var @event = await _events.GetAsync(request.EventId);
            if (@event is null)
            {
                throw new Exception($"Event with id {request.EventId} does not exist");
            }
            var booking = new Booking(request.CustomerId, @event, request.BookingDate);     

            await _booking.AddAsync(booking);
            await _booking.SaveAsync();

            return booking;
        }
    }
}
