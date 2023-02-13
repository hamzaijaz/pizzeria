using AutoFixture;
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
        private readonly IFixture _fixture;
        public GetAllLocationsQueryTests() 
        {
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetAllLocationsQuery_ShouldReturnAllLocations()
        {
            // Arrange
            var fixtureLocations = _fixture.Create<List<LocationDto>>();

            //var locations = new List<Location>
            //{
            //    new Location { Id = 1, Name = "Location 1", Address = "Address 1" },
            //    new Location { Id = 2, Name = "Location 2", Address = "Address 2" }
            //};

            //var locationDtos = locations.Select(x => new LocationDto { Id = x.Id, Name = x.Name, Address = x.Address }).ToList();

            var mockAdminRepository = new Mock<IAdminRepository>();
            mockAdminRepository
                .SetupSequence(x => x.GetAllLocationsAsync())
                .ReturnsAsync(fixtureLocations);

            var handler = new GetAllLocationsQuery.GetAllLocationsQueryHandler(mockAdminRepository.Object);

            // Act
            var result = await handler.Handle(new GetAllLocationsQuery(), CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(fixtureLocations);
            result.Count.Should().Be(fixtureLocations.Count);

            for (int i = 0; i < result.Count; i++)
            {
                result[i].Id.Should().Be(fixtureLocations[i].Id);
                result[i].Address.Should().Be(fixtureLocations[i].Address);
                result[i].Name.Should().Be(fixtureLocations[i].Name);
            }
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

            var handler = new GetAllLocationsQuery.GetAllLocationsQueryHandler(mockAdminRepository.Object);

            // Act
            var result = await handler.Handle(new GetAllLocationsQuery(), CancellationToken.None);

            // Assert
            result.Count().Should().Be(0);
        }
    }
}
