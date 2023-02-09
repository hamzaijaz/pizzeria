using FluentValidation;
using pizzeriaserver.Application.Commands;

namespace pizzeriaserver.Application.Validators
{
    public class CreateToppingCommandValidator : AbstractValidator<CreateToppingCommand>
    {
        public CreateToppingCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotNull().WithMessage("Name must not be null")
                .NotEmpty().WithMessage("Name must not be empty");
        }
    }
}
