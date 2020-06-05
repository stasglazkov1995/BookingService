using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookMe.BookingService.Application.Queries.EventQueries;
using BookMe.BookingService.Data.Queries;
using BookMe.BookingService.Data.Repositories.Abstractions;
using BookMe.BookingService.Domain;
using MediatR;

namespace BookMe.BookingService.Application.QueryHandlers.EventQueries
{
    public class GetUserEventsQueryHandler : IRequestHandler<GetUserEventsQuery, Event[]>
    {
        private readonly IGeneralRepository<Event> _events;

        public GetUserEventsQueryHandler(IGeneralRepository<Event> events)
        {
            _events = events;
        }

        public async Task<Event[]> Handle(GetUserEventsQuery command, CancellationToken cancellationToken)
        {
            var events = await _events
                .GetUserEvents(command.UserId)
                .AsNoTracking()
                .ToArrayAsync();

            return events;
        }
    }
}
