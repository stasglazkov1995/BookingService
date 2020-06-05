using System;
using BookMe.BookingService.Application.Commands.Abstractions;
using BookMe.BookingService.Domain;
using FluentValidation;
using MediatR;

namespace BookMe.BookingService.Application.Commands.BookingCommands
{
    public class PlaceBookingCommand : IRequest<Booking> , IValidatabe
    {
        public Guid EventId { get; private set; }

        public Guid CustomerId { get; private set; }

        public DateTime BookingDate { get; private set; }      
        
        public PlaceBookingCommand(
            Guid eventId,
            Guid customerId,
            DateTime bookingDate
            )
        {
            EventId = eventId;
            CustomerId = customerId;
            BookingDate = bookingDate;
        }

        #region VALIDATION

        public bool IsValid()
             => new PlaceBookingCommandValidator().Validate(this).IsValid;

        public void Validate()
            => new PlaceBookingCommandValidator().ValidateAndThrow(this);

        public class PlaceBookingCommandValidator : AbstractValidator<PlaceBookingCommand>
        {
            public PlaceBookingCommandValidator() : base()
            {
                RuleFor(x => x.EventId).NotEmpty();
                RuleFor(x => x.CustomerId).NotEmpty();
                RuleFor(x => x.BookingDate).NotEmpty();
            }
        }

        #endregion
    }
}
