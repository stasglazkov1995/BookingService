using BookMe.BookingService.Data.Mappers;
using BookMe.BookingService.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookMe.BookingService.Data
{
    public class ApplicationDbContext : DbContext
    {
        private static readonly string Schema = "BookingService";

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options)
        {  }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.ApplyConfiguration(new EventMapper());
            modelBuilder.ApplyConfiguration(new BookingMapper());
        }
    }
}