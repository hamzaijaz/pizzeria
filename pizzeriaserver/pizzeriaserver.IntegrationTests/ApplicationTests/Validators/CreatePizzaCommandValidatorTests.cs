using FluentAssertions;
using pizzeriaserver.Application.Commands;
using pizzeriaserver.Application.Validators;

namespace pizzeriaserver.IntegrationTests.ApplicationTests.Validators
{
    [Collection("Tests")]
    public class CreatePizzaCommandValidatorTests
    {
        private readonly CreatePizzaCommandValidator _validator;

        public CreatePizzaCommandValidatorTests()
        {
            _validator = new CreatePizzaCommandValidator();
        }

        [Fact]
        public void When_Name_Is_Null_Should_Return_Error()
        {
            // Arrange
            var command = new CreatePizzaCommand
            {
                Name = null,
                Description = "Delicious Pizza",
                Price = 10.99m,
                LocationIds = new List<int> { 1, 2, 3 }
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
            var command = new CreatePizzaCommand
            {
                Name = string.Empty,
                Description = "Delicious Pizza",
                Price = 10.99m,
                LocationIds = new List<int> { 1, 2, 3 }
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
            var command = new CreatePizzaCommand
            {
                Name = "Margherita",
                Description = null,
                Price = 10.99m,
                LocationIds = new List<int> { 1, 2, 3 }
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
            var command = new CreatePizzaCommand
            {
                Name = "Margherita",
                Description = string.Empty,
                Price = 10.99m,
                LocationIds = new List<int> { 1, 2, 3 }
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
            var command = new CreatePizzaCommand
            {
                Name = "Margherita",
                Description = "Delicious Pizza",
                Price = -20m,
                LocationIds = new List<int> { 1, 2, 3 }
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Pizza price must be greater than or equal to zero");
        }

        [Fact]
        public void When_LocationIds_Is_Null_Should_Return_Error()
        {
            // Arrange
            var command = new CreatePizzaCommand
            {
                Name = "Margherita",
                Description = "Delicious Pizza",
                Price = 20m,
                LocationIds = null
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Locations list must not be null");
        }

        [Fact]
        public void When_LocationIds_Is_Empty_Should_Return_Error()
        {
            // Arrange
            var command = new CreatePizzaCommand
            {
                Name = "Margherita",
                Description = "Delicious Pizza",
                Price = 20m,
                LocationIds = new List<int>()
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Please select atleast one location");
        }

        [Fact]
        public void When_Valid_Input_Is_Provided_Should_Return_Success()
        {
            // Arrange
            var command = new CreatePizzaCommand
            {
                Name = "Margherita",
                Description = "Delicious Pizza",
                Price = 20m,
                LocationIds = new List<int> { 1, 2, 3 }
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }
    }
}
