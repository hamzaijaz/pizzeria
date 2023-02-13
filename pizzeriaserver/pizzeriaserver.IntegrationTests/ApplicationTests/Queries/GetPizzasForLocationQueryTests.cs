using AutoFixture;
using FluentAssertions;
using Moq;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Application.Queries;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.IntegrationTests.ApplicationTests.Queries
{
    [Collection("Tests")] // XUnit Requirement
    public class GetPizzasForLocationQueryTests
    {
        private Mock<IPizzaRepository> _pizzaRepositoryMock;
        private GetPizzasForLocationQuery.GetPizzasForLocationQueryHandler _handler;
        private readonly IFixture _fixture;

        public GetPizzasForLocationQueryTests()
        {
            _pizzaRepositoryMock = new Mock<IPizzaRepository>();
            _handler = new GetPizzasForLocationQuery.GetPizzasForLocationQueryHandler(_pizzaRepositoryMock.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetPizzasForLocationQuery_GivenValidLocationId_ShouldReturnPizzasForLocation()
        {
            // Arrange
            int locationId = 1;
            var expectedPizzas = _fixture.Create<List<PizzaDto>>();
            
            _pizzaRepositoryMock.Setup(x => x.GetPizzasForLocationAsync(locationId))
                .ReturnsAsync(expectedPizzas);

            // Act
            var query = new GetPizzasForLocationQuery { LocationId = locationId };
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(expectedPizzas);
        }


    }
}
