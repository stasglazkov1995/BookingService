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
    public class DeleteEventCommandHandlerTests
    {
        private readonly IGeneralRepository<Event> _repository;
        private readonly IMediator _mediator;
        private readonly ILogger<DeleteEventCommandHandler> _logger;
        private readonly Event _event;
        private readonly Event _deletedEvent;

        public DeleteEventCommandHandlerTests()
        {
            _repository = Substitute.For<IGeneralRepository<Event>>();
            _mediator = Substitute.For<IMediator>();
            _logger = Substitute.For<ILogger<DeleteEventCommandHandler>>();
            _event = new Event(Guid.NewGuid(), Guid.NewGuid().ToString());
            _deletedEvent = new Event(Guid.NewGuid(), Guid.NewGuid().ToString());
            _deletedEvent.Delete();

            _repository.GetAsync(_event.Id).Returns(_event);
            _repository.GetAsync(_deletedEvent.Id).Returns(_deletedEvent);
        }

        [Fact]
        public async Task It_deletes_event_and_publishes_corresponding_event()
        {
            // Arrange
            _mediator.ClearReceivedCalls();
            _repository.ClearReceivedCalls();
            var handler = new DeleteEventCommandHandler(_repository, _mediator, _logger);
            var command = new DeleteEventCommand(_event.Id);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.Should().BeTrue();
            _event.IsDeleted.Should().BeTrue();

            // Ensure changes was saved
            await _repository.Received(1).SaveAsync();

            // Ensure corresponding event was published
            await _mediator.Received(1).Publish(Arg.Any<EventDeletedEvent>());
        }

        [Fact]
        public async Task It_returns_true_and_does_nothing_if_event_already_deleted()
        {
            // Arrange
            _mediator.ClearReceivedCalls();
            _repository.ClearReceivedCalls();
            var handler = new DeleteEventCommandHandler(_repository, _mediator, _logger);
            var command = new DeleteEventCommand(_deletedEvent.Id);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.Should().BeTrue();
            _deletedEvent.IsDeleted.Should().BeTrue();

            // Ensure changes was not saved
            await _repository.Received(0).SaveAsync();

            // Ensure corresponding event was not published
            await _mediator.Received(0).Publish(Arg.Any<EventDeletedEvent>());
        }

        [Fact]
        public void It_throws_exception_if_event_was_not_found()
        {
            // Arrange
            var handler = new DeleteEventCommandHandler(_repository, _mediator, _logger);
            var command = new DeleteEventCommand(Guid.NewGuid()); // not existing event id

            // Act
            Task<bool> result = handler.Handle(command, default);

            // Assert
            result.Should().Throws<Exception>();
        }
    }
}
