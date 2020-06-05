using System;
using System.Linq;
using BookMe.BookingService.Data.Repositories.Abstractions;
using BookMe.BookingService.Domain;

namespace BookMe.BookingService.Data.Queries
{
    public static class EventQueries
    {
        public static IQueryable<Event> GetUserEvents(this IGeneralRepository<Event> events, Guid userId)
        {
            return events.All().Where(t => t.UserId == userId);
        }

        public static IQueryable<Event> GetUserEvents(this IQueryable<Event> events, Guid userId)
        {
            return events.Where(t => t.UserId == userId);
        }
    }
}
