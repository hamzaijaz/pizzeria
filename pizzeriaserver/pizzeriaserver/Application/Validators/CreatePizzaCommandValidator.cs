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

            RuleFor(v => v.Location)
                .NotNull().WithMessage("Pizza location must not be null")
                .NotEmpty().WithMessage("Pizza location must not be empty");
        }
    }
}
