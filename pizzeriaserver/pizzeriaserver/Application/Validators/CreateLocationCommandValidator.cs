using FluentValidation;
using pizzeriaserver.Application.Commands;

namespace pizzeriaserver.Application.Validators
{
    public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
    {
        public CreateLocationCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotNull().WithMessage("Name must not be null")
                .NotEmpty().WithMessage("Name must not be empty");

            RuleFor(v => v.Address)
                .NotNull().WithMessage("Address must not be null")
                .NotEmpty().WithMessage("Address must not be empty");
        }
    }
}
