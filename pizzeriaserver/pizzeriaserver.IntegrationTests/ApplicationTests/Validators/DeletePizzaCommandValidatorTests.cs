using FluentAssertions;
using pizzeriaserver.Application.Commands;
using pizzeriaserver.Application.Validators;

namespace pizzeriaserver.IntegrationTests.ApplicationTests.Validators
{
    [Collection("Tests")]
    public class DeletePizzaCommandValidatorTests
    {
        private readonly DeletePizzaCommandValidator _validator;

        public DeletePizzaCommandValidatorTests()
        {
            _validator = new DeletePizzaCommandValidator();
        }

        [Fact]
        public void When_PizzaId_Is_Negative_Should_Return_Error()
        {
            // Arrange
            var query = new DeletePizzaCommand
            {
                Id = -1,
                PizzaLocationId = 2
            };

            // Act
            var result = _validator.Validate(query);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Id must be greater than zero");
        }

        [Fact]
        public void When_LocationId_Is_Negative_Should_Return_Error()
        {
            // Arrange
            var query = new DeletePizzaCommand
            {
                Id = 1,
                PizzaLocationId = -2
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
            var query = new DeletePizzaCommand
            {
                Id = 1,
                PizzaLocationId = 2
            };

            // Act
            var result = _validator.Validate(query);

            // Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }
    }
}
