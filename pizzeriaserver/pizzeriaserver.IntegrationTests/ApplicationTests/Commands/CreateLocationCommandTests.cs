using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using pizzeriaserver.Application.Commands;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.IntegrationTests.ApplicationTests.Commands
{
    [Collection("Tests")] // XUnit Requirement
    public class CreateLocationCommandTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IAdminRepository> _mockAdminRepository;
        private readonly CreateLocationCommand.CreateLocationCommandHandler _handler;
        private readonly Mock<ILogger<CreateLocationCommand>> _logger;

        public CreateLocationCommandTests()
        {
            _fixture = new Fixture();
            _mockAdminRepository = new Mock<IAdminRepository>();
            _logger = new Mock<ILogger<CreateLocationCommand>>();
            _handler = new CreateLocationCommand.CreateLocationCommandHandler(_mockAdminRepository.Object, _logger.Object);
        }

        [Fact]
        public async Task CreateLocationCommand_ShouldAddLocationAndReturnLocationDto()
        {
            // Arrange
            var locationDetails = _fixture.Create<LocationDto>();
            _mockAdminRepository
                .Setup(x => x.AddLocationAsync(It.IsAny<LocationDto>()))
                .ReturnsAsync(locationDetails);

            // Act
            var result = await _handler.Handle(
                new CreateLocationCommand { Name = locationDetails.Name, Address = locationDetails.Address },
                CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(locationDetails);
        }
    }
}
