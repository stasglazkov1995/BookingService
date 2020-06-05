using System;
using System.Collections.Generic;
using BookMe.BookingService.Domain.Abstractions;

namespace BookMe.BookingService.Domain
{
    public class Event : Entity
    {
        public Guid UserId { get; protected set; }

        public string Number { get; protected set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LineOfBusiness { get; set; }

        public bool IsActive { get; protected set; }

        public bool IsDeleted { get; protected set; }

        public ICollection<Booking> Bookings { get; set; }

        public Event(Guid userId, string number)
        {
            UserId = userId;
            Number = number;
            IsActive = true;
            IsDeleted = false;
        }

        public void Activate()
        {
            if (IsDeleted)
            {
                throw new InvalidOperationException("Can not activate deleted event");
            }

            IsActive = true;
        }

        public void Deactivate()
        {
            if (IsDeleted)
            {
                throw new InvalidOperationException("Can not deactivate deleted event");
            }

            IsActive = false;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
