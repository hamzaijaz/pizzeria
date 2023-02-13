using FluentAssertions;
using pizzeriaserver.Application.Queries;
using pizzeriaserver.Application.Validators;

namespace pizzeriaserver.IntegrationTests.ApplicationTests.Validators
{
    [Collection("Tests")]
    public class GetPizzasForLocationQueryValidatorTests
    {
        private readonly GetPizzasForLocationQueryValidator _validator;

        public GetPizzasForLocationQueryValidatorTests()
        {
            _validator = new GetPizzasForLocationQueryValidator();
        }

        [Fact]
        public void When_LocationId_Is_Negative_Should_Return_Error()
        {
            // Arrange
            var query = new GetPizzasForLocationQuery
            {
                LocationId = -1
            };

            // Act
            var result = _validator.Validate(query);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Location Id must be greater than zero");
        }

        [Fact]
        public void When_Valid_Input_Is_Provided_Should_Return_Success()
        {
            // Arrange
            var query = new GetPizzasForLocationQuery
            {
                LocationId = 1
            };

            // Act
            var result = _validator.Validate(query);

            // Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }
    }
}
