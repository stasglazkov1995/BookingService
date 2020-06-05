using System;
using System.Threading.Tasks;
using BookMe.BookingService.Application.CommandHandlers.EventCommands;
using BookMe.BookingService.Application.Commands.EventCommands;
using BookMe.BookingService.Application.Events.EventEvents;
using BookMe.BookingService.Data.Repositories.Abstractions;
using BookMe.BookingService.Domain;
using FluentAssertions;
using MediatR;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace BookMe.BookingService.UnitTests.Application.CommandHandlers
{
    public class UpdateEventCommandHandlerTests
    {
        [Fact]
        public async Task It_updates_event_and_publishes_corresponding_event()
        {
            // Arrange
            var @event = new Event(
                userId: Guid.NewGuid(),
                number: Guid.NewGuid().ToString());

            var mediator = Substitute.For<IMediator>();
            var repository = Substitute.For<IGeneralRepository<Event>>();
            var handler = new UpdateEventCommandHandler(repository, mediator);
            var command = new UpdateEventCommand(
                id: @event.Id,
                name: "Test",
                description: "Test",
                lineOfBusiness: "Test");

            repository.GetAsync(Arg.Any<Guid>()).Returns(@event);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(command.Id);
            result.Name.Should().Be(command.Name);
            result.Description.Should().Be(command.Description);
            result.LineOfBusiness.Should().Be(command.LineOfBusiness);

            // Ensure event was published
            await mediator.Received(1).Publish(Arg.Any<EventUpdatedEvent>());

            // Ensure changes was saved
            await repository.Received(1).SaveAsync();
        }

        [Fact]
        public void It_throws_exception_if_event_was_not_found()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var repository = Substitute.For<IGeneralRepository<Event>>();
            var handler = new UpdateEventCommandHandler(repository, mediator);
            var command = new UpdateEventCommand(
                id: Guid.NewGuid(), // not existing event id
                name: "Test",
                description: "Test",
                lineOfBusiness: "Test");

            // Act
            Task<Event> result = handler.Handle(command, default);

            // Assert
            result.Should().Throws<Exception>();
        }
    }
}
