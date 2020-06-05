using System;
using System.Threading.Tasks;
using BookMe.BookingService.Application.CommandHandlers.EventCommands;
using BookMe.BookingService.Application.Commands.EventCommands;
using BookMe.BookingService.Data.Repositories.Abstractions;
using BookMe.BookingService.Domain;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace BookMe.BookingService.UnitTests.Application.CommandHandlers
{
    public class CreateEventCommandHandlerTests
    {
        [Fact]
        public async Task It_creates_new_event()
        {
            // Arrange
            var repository = Substitute.For<IGeneralRepository<Event>>();
            var handler = new CreateEventCommandHandler(repository);
            var command = new CreateEventCommand(
                userId: Guid.NewGuid(),
                name: "Test",
                description: "Test",
                lineOfBusiness: "Test");

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBeEmpty();
            result.Name.Should().Be(command.Name);
            result.Description.Should().Be(command.Description);
            result.LineOfBusiness.Should().Be(command.LineOfBusiness);

            // Ensure changes was saved
            await repository.Received(1).SaveAsync();
        }
    }
}
