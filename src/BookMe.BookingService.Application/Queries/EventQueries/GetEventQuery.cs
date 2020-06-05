using System;
using BookMe.BookingService.Domain;
using MediatR;

namespace BookMe.BookingService.Application.Queries.EventQueries
{
    public class GetEventQuery : IRequest<Event>
    {
        public Guid Id { get; }

        public GetEventQuery(Guid id)
        {
            Id = id;
        }
    }
}
