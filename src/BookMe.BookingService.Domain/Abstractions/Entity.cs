using System;

namespace BookMe.BookingService.Domain.Abstractions
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Version { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
