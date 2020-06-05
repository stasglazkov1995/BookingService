using System;
namespace BookMe.BookingService.Api.Models.Bookings
{
    public class PlaceBookingModel
    {       
        public Guid EventId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime BookingDate { get; set; }
    }
    
}
