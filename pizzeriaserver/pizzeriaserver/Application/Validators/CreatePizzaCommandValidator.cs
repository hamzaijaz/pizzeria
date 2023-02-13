using FluentValidation;
using pizzeriaserver.Application.Commands;

namespace pizzeriaserver.Application.Validators
{
    public class CreatePizzaCommandValidator : AbstractValidator<CreatePizzaCommand>
    {
        public CreatePizzaCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotNull().WithMessage("Name must not be null")
                .NotEmpty().WithMessage("Name must not be empty");

            RuleFor(v => v.Description)
                .NotNull().WithMessage("Pizza description must not be null")
                .NotEmpty().WithMessage("Pizza description must not be empty");

            RuleFor(v => v.Price)
                .NotNull().WithMessage("Pizza price must not be null")
                .NotEmpty().WithMessage("Pizza description must not be empty")
                .GreaterThanOrEqualTo(0).WithMessage("Pizza price must be greater than or equal to zero");

            RuleFor(v => v.LocationIds)
                .NotNull().WithMessage("Locations list must not be null")
                .NotEmpty().WithMessage("Please select atleast one location");
        }
    }
}
