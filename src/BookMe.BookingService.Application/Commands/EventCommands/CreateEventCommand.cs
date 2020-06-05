using System;
using BookMe.BookingService.Application.Commands.Abstractions;
using BookMe.BookingService.Domain;
using FluentValidation;
using MediatR;

namespace BookMe.BookingService.Application.Commands.EventCommands
{
    public class CreateEventCommand : IRequest<Event>, IValidatabe
    {
        public Guid UserId { get; }

        public string Name { get; }

        public string Description { get; }

        public string LineOfBusiness { get; }

        public CreateEventCommand(
            Guid userId,
            string name,
            string description,
            string lineOfBusiness)
        {
            UserId = userId;
            Name = name;
            Description = description;
            LineOfBusiness = lineOfBusiness;
        }


        #region VALIDATION

        public bool IsValid()
             => new CreateEventCommandValidator().Validate(this).IsValid;

        public void Validate()
            => new CreateEventCommandValidator().ValidateAndThrow(this);

        public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
        {
            public CreateEventCommandValidator() : base()
            {
                RuleFor(x => x.UserId).NotEmpty();
                RuleFor(x => x.Name).NotNull().NotEmpty();
                RuleFor(x => x.Description).NotNull().NotEmpty();
                RuleFor(x => x.LineOfBusiness).NotNull().NotEmpty();
            }
        }

        #endregion
    }
}
