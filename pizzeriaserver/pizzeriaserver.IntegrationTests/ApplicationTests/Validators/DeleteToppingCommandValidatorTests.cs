using FluentAssertions;
using pizzeriaserver.Application.Commands;
using pizzeriaserver.Application.Validators;

namespace pizzeriaserver.IntegrationTests.ApplicationTests.Validators
{
    [Collection("Tests")]
    public class DeleteToppingCommandValidatorTests
    {
        private readonly DeleteToppingCommandValidator _validator;

        public DeleteToppingCommandValidatorTests()
        {
            _validator = new DeleteToppingCommandValidator();
        }

        [Fact]
        public void When_ToppingId_Is_Negative_Should_Return_Error()
        {
            // Arrange
            var query = new DeleteToppingCommand
            {
                Id = -1
            };

            // Act
            var result = _validator.Validate(query);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.ErrorMessage == "Topping Id must be greater than zero");
        }

        [Fact]
        public void When_Valid_Input_Is_Provided_Should_Return_Success()
        {
            // Arrange
            var query = new DeleteToppingCommand
            {
                Id = 1
            };

            // Act
            var result = _validator.Validate(query);

            // Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }
    }
}
