﻿using System;

namespace BookMe.BookingService.Api.Models.Events
{
    public class EventModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LineOfBusiness { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }
    }
}
