using FluentAssertions;
using Moq;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Application.Queries;
using pizzeriaserver.Data.Entities;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.IntegrationTests.ApplicationTests.Queries
{
    [Collection("Tests")] // XUnit Requirement
    public class GetAllLocationsQueryTests
    {
        public GetAllLocationsQueryTests() { }

        [Fact]
        public async Task GetAllLocationsQuery_ShouldReturnAllLocations()
        {
            // Arrange
            var locations = new List<Location>
            {
                new Location { Id = 1, Name = "Location 1", Address = "Address 1" },
                new Location { Id = 2, Name = "Location 2", Address = "Address 2" }
            };

            var locationDtos = locations.Select(x => new LocationDto { Id = x.Id, Name = x.Name, Address = x.Address }).ToList();

            var mockAdminRepository = new Mock<IAdminRepository>();
            mockAdminRepository
                .SetupSequence(x => x.GetAllLocationsAsync())
                .ReturnsAsync(locationDtos);

            var handler = new GetAllLocationsQuery.GetAllLocationsHandler(mockAdminRepository.Object);

            // Act
            var result = await handler.Handle(new GetAllLocationsQuery(), CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(locationDtos);
            result.Count.Should().Be(2);
            result[0].Id.Should().Be(1);
            result[0].Name.Should().Be("Location 1");
            result[0].Address.Should().Be("Address 1");
            result[1].Id.Should().Be(2);
            result[1].Name.Should().Be("Location 2");
            result[1].Address.Should().Be("Address 2");
        }

        [Fact]
        public async Task GetAllLocationsQuery_ShouldReturn_EmptyLocations_WhenNoLocationIsStored()
        {
            // Arrange
            var locations = new List<Location>();

            var locationDtos = locations.Select(x => new LocationDto { Id = x.Id, Name = x.Name, Address = x.Address }).ToList();

            var mockAdminRepository = new Mock<IAdminRepository>();
            mockAdminRepository
                .SetupSequence(x => x.GetAllLocationsAsync())
                .ReturnsAsync(locationDtos);

            var handler = new GetAllLocationsQuery.GetAllLocationsHandler(mockAdminRepository.Object);

            // Act
            var result = await handler.Handle(new GetAllLocationsQuery(), CancellationToken.None);

            // Assert
            result.Count().Should().Be(0);
        }
    }
}
