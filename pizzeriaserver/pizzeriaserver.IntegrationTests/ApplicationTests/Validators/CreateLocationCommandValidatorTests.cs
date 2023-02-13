using FluentAssertions;
using pizzeriaserver.Application.Commands;
using pizzeriaserver.Application.Validators;

namespace pizzeriaserver.IntegrationTests.ApplicationTests.Validators
{
    [Collection("Tests")]
    public class CreateLocationCommandValidatorTests
    {
        private readonly CreateLocationCommandValidator _validator;

        public CreateLocationCommandValidatorTests()
        {
            _validator = new CreateLocationCommandValidator();
        }

        [Fact]
        public void When_Name_Is_Null_Should_Return_Error()
        {
            // Arrange
            var command = new CreateLocationCommand
            {
                Name = null,
                Address = "22 City Road"
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Name must not be null");
        }

        [Fact]
        public void When_Name_Is_Empty_Should_Return_Error()
        {
            // Arrange
            var command = new CreateLocationCommand
            {
                Name = string.Empty,
                Address = "22 City Road"
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Name must not be empty");
        }

        [Fact]
        public void When_Description_Is_Null_Should_Return_Error()
        {
            // Arrange
            var command = new CreateLocationCommand
            {
                Name = "Margherita",
                Address = null
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Address must not be null");
        }

        [Fact]
        public void When_Description_Is_Empty_Should_Return_Error()
        {
            // Arrange
            var command = new CreateLocationCommand
            {
                Name = "Margherita",
                Address = string.Empty
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Address must not be empty");
        }

        [Fact]
        public void When_Valid_Input_Is_Provided_Should_Return_Success()
        {
            // Arrange
            var command = new CreateLocationCommand
            {
                Name = "Margherita",
                Address = "22 City Road"
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }
    }
}
