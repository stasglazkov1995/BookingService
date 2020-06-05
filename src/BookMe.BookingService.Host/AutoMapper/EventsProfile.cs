using AutoMapper;
using BookMe.BookingService.Api.Models.Events;
using BookMe.BookingService.Domain;

namespace BookMe.BookingService.Host.AutoMapper
{
    public class EventsProfile : Profile
    {
        public EventsProfile()
        {
            CreateMap<Event, EventModel>();
        }
    }
}
