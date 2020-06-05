using System;
using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Queries.EventQueries;
using BookMe.BookingService.Data.Repositories.Abstractions;
using BookMe.BookingService.Domain;
using MediatR;

namespace BookMe.BookingService.Application.QueryHandlers.EventQueries
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, Event>
    {
        private readonly IGeneralRepository<Event> _events;
        public GetEventQueryHandler(IGeneralRepository<Event> events)
        {
            _events = events;
        }

        public async Task<Event> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var @event = await _events.GetAsync(request.Id);

            return @event;
        }
    }
}
