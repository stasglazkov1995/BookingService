using BookMe.BookingService.Data.Mappers.Abstractions;
using BookMe.BookingService.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookMe.BookingService.Data.Mappers
{
    public class BookingMapper : EntityMapper<Booking>
    {
        public override void Configure(EntityTypeBuilder<Booking> builder)
        {
            base.Configure(builder);

            builder.HasOne(booing => booing.Event)
                .WithMany(@event => @event.Bookings)
                .HasForeignKey(bookig => bookig.EventId);
        }
    }
}
