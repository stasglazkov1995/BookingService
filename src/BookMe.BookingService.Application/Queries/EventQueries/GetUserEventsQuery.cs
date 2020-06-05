using System;
using BookMe.BookingService.Domain;
using MediatR;

namespace BookMe.BookingService.Application.Queries.EventQueries
{
    public class GetUserEventsQuery : IRequest<Event[]>
    {
        public Guid UserId { get; }

        public GetUserEventsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
