using FluentAssertions;
using pizzeriaserver.Application.Commands;
using pizzeriaserver.Application.Validators;

namespace pizzeriaserver.IntegrationTests.ApplicationTests.Validators
{
    [Collection("Tests")]
    public class DeleteLocationCommandValidatorTests
    {
        private readonly DeleteLocationCommandValidator _validator;

        public DeleteLocationCommandValidatorTests()
        {
            _validator = new DeleteLocationCommandValidator();
        }

        [Fact]
        public void When_LocationId_Is_Negative_Should_Return_Error()
        {
            // Arrange
            var query = new DeleteLocationCommand
            {
                Id = -1
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
            var query = new DeleteLocationCommand
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
