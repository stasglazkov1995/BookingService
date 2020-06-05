using System;
using System.Threading.Tasks;
using BookMe.BookingService.Application.CommandHandlers.EventCommands;
using BookMe.BookingService.Application.Commands.EventCommands;
using BookMe.BookingService.Application.Events.EventEvents;
using BookMe.BookingService.Data.Repositories.Abstractions;
using BookMe.BookingService.Domain;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace BookMe.BookingService.UnitTests.Application.CommandHandlers
{
    public class ActivateEventCommandHandlerTests
    {
        private readonly IGeneralRepository<Event> _repository;
        private readonly IMediator _mediator;
        private readonly ILogger<ActivateEventCommandHandler> _logger;
        private readonly Event _deactivatedEvent;
        private readonly Event _activatedEvent;

        public ActivateEventCommandHandlerTests()
        {
            _repository = Substitute.For<IGeneralRepository<Event>>();
            _mediator = Substitute.For<IMediator>();
            _logger = Substitute.For<ILogger<ActivateEventCommandHandler>>();
            _deactivatedEvent = new Event(Guid.NewGuid(), Guid.NewGuid().ToString());
            _activatedEvent = new Event(Guid.NewGuid(), Guid.NewGuid().ToString());
            _deactivatedEvent.Deactivate();

            _repository.GetAsync(_deactivatedEvent.Id).Returns(_deactivatedEvent);
            _repository.GetAsync(_activatedEvent.Id).Returns(_activatedEvent);
        }

        [Fact]
        public async Task It_activates_event_and_publishes_corresponding_event()
        {
            // Arrange
            _mediator.ClearReceivedCalls();
            _repository.ClearReceivedCalls();
            var handler = new ActivateEventCommandHandler(_repository, _mediator, _logger);
            var command = new ActivateEventCommand(_deactivatedEvent.Id);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.Should().BeTrue();
            _deactivatedEvent.IsActive.Should().BeTrue();

            // Ensure changes was saved
            await _repository.Received(1).SaveAsync();

            // Ensure corresponding event was published
            await _mediator.Received(1).Publish(Arg.Any<EventActivatedEvent>());
        }

        [Fact]
        public async Task It_returns_true_and_does_nothing_if_event_already_activated()
        {
            // Arrange
            _mediator.ClearReceivedCalls();
            _repository.ClearReceivedCalls();
            var handler = new ActivateEventCommandHandler(_repository, _mediator, _logger);
            var command = new ActivateEventCommand(_activatedEvent.Id);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.Should().BeTrue();
            _activatedEvent.IsActive.Should().BeTrue();

            // Ensure changes was not saved
            await _repository.Received(0).SaveAsync();

            // Ensure corresponding event was not published
            await _mediator.Received(0).Publish(Arg.Any<EventActivatedEvent>());
        }

        [Fact]
        public void It_throws_exception_if_event_was_not_found()
        {
            // Arrange
            var handler = new ActivateEventCommandHandler(_repository, _mediator, _logger);
            var command = new ActivateEventCommand(Guid.NewGuid()); // not existing event id

            // Act
            Task<bool> result = handler.Handle(command, default);

            // Assert
            result.Should().Throws<Exception>();
        }
    }
}
