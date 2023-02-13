using FluentAssertions;
using pizzeriaserver.Application.Commands;
using pizzeriaserver.Application.Validators;

namespace pizzeriaserver.IntegrationTests.ApplicationTests.Validators
{
    [Collection("Tests")]
    public class UpdateToppingCommandValidatorTests
    {
        private readonly UpdateToppingCommandValidator _validator;

        public UpdateToppingCommandValidatorTests()
        {
            _validator = new UpdateToppingCommandValidator();
        }

        [Fact]
        public void When_ToppingId_Is_Negative_Should_Return_Error()
        {
            // Arrange
            var command = new UpdateToppingCommand
            {
                Id = -1,
                Name = "Some topping"
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Topping Id must be greater than zero");
        }

        [Fact]
        public void When_ToppingName_Is_Null_Should_Return_Error()
        {
            // Arrange
            var command = new UpdateToppingCommand
            {
                Id = 1,
                Name = null
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Topping name must not be null");
        }

        [Fact]
        public void When_ToppingName_Is_Empty_Should_Return_Error()
        {
            // Arrange
            var command = new UpdateToppingCommand
            {
                Id = 1,
                Name = ""
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Topping name must not be empty");
        }

        [Fact]
        public void When_Valid_Input_Is_Provided_Should_Return_Success()
        {
            // Arrange
            var command = new UpdateToppingCommand
            {
                Id = 1,
                Name = "Some topping"
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }
    }
}
