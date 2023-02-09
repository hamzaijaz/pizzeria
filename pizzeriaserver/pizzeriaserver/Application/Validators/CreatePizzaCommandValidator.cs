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
                .NotNull().WithMessage("Price must not be null")
                .NotEmpty().WithMessage("Price must not be empty")
                .LessThan(0).WithMessage("Price must be greater than or equal to zero");

            RuleFor(v => v.Location)
                .NotNull().WithMessage("Pizza location must not be null")
                .NotEmpty().WithMessage("Pizza location must not be empty");
        }
    }
}
