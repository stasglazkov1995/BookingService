using AutoMapper;
using BookMe.BookingService.Api.Models.Bookings;
using BookMe.BookingService.Domain;

namespace BookMe.BookingService.Host.AutoMapper
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingModel>();
        }
    }
}
