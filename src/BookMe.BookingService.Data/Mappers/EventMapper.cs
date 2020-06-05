using BookMe.BookingService.Domain;
using BookMe.BookingService.Data.Mappers.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookMe.BookingService.Data.Mappers
{
    public class EventMapper : EntityMapper<Event>
    {
        public override void Configure(EntityTypeBuilder<Event> builder)
        {
            base.Configure(builder);
        }
    }
}
