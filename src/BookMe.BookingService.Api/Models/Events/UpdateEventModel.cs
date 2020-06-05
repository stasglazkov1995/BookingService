using System;

namespace BookMe.BookingService.Api.Models.Events
{
    public class UpdateEventModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LineOfBusiness { get; set; }
    }
}
