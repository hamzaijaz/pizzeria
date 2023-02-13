using AutoFixture;
using FluentAssertions;
using Moq;
using pizzeriaserver.Application.Commands;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzeriaserver.IntegrationTests.ApplicationTests.Commands
{
    [Collection("Tests")] // XUnit Requirement
    public class CreateLocationCommandTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IAdminRepository> _mockAdminRepository;
        private readonly CreateLocationCommand.CreateLocationCommandHandler _handler;

        public CreateLocationCommandTests()
        {
            _fixture = new Fixture();
            _mockAdminRepository = new Mock<IAdminRepository>();
            _handler = new CreateLocationCommand.CreateLocationCommandHandler(_mockAdminRepository.Object);
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
