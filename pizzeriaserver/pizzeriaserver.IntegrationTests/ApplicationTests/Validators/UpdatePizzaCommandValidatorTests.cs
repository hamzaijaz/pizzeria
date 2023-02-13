using FluentAssertions;
using pizzeriaserver.Application.Commands;
using pizzeriaserver.Application.Validators;

namespace pizzeriaserver.IntegrationTests.ApplicationTests.Validators
{
    [Collection("Tests")]
    public class UpdatePizzaCommandValidatorTests
    {
        private readonly UpdatePizzaCommandValidator _validator;

        public UpdatePizzaCommandValidatorTests()
        {
            _validator = new UpdatePizzaCommandValidator();
        }

        [Fact]
        public void When_Name_Is_Null_Should_Return_Error()
        {
            // Arrange
            var command = new UpdatePizzaCommand
            {
                Name = null,
                Description = "Delicious Pizza",
                Price = 10.99m,
                Id = 1
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
            var command = new UpdatePizzaCommand
            {
                Name = string.Empty,
                Description = "Delicious Pizza",
                Price = 10.99m,
                Id = 1
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
            var command = new UpdatePizzaCommand
            {
                Name = "Margherita",
                Description = null,
                Price = 10.99m,
                Id = 1
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Pizza description must not be null");
        }

        [Fact]
        public void When_Description_Is_Empty_Should_Return_Error()
        {
            // Arrange
            var command = new UpdatePizzaCommand
            {
                Name = "Margherita",
                Description = string.Empty,
                Price = 10.99m,
                Id = 1
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Pizza description must not be empty");
        }

        [Fact]
        public void When_Price_Is_LessThanZero_Should_Return_Error()
        {
            // Arrange
            var command = new UpdatePizzaCommand
            {
                Name = "Margherita",
                Description = "Delicious Pizza",
                Price = -20m,
                Id = 1
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Price must be greater than or equal to zero");
        }

        [Fact]
        public void When_Id_Is_Negative_Should_Return_Error()
        {
            // Arrange
            var command = new UpdatePizzaCommand
            {
                Name = "Margherita",
                Description = "Delicious Pizza",
                Price = 20m,
                Id = -5
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Pizza Id must be greater than zero");
        }

        [Fact]
        public void When_Valid_Input_Is_Provided_Should_Return_Success()
        {
            // Arrange
            var command = new UpdatePizzaCommand
            {
                Name = "Margherita",
                Description = "Delicious Pizza",
                Price = 20m,
                Id = 1
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }
    }
}
