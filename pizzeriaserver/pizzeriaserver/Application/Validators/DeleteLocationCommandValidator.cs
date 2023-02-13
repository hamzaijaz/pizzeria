using FluentValidation;
using pizzeriaserver.Application.Commands;

namespace pizzeriaserver.Application.Validators
{
    public class DeleteLocationCommandValidator : AbstractValidator<DeleteLocationCommand>
    {
        public DeleteLocationCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotNull().WithMessage("Location Id must not be null")
                .NotEmpty().WithMessage("Location Id must not be empty")
                .GreaterThan(0).WithMessage("Location Id must be greater than zero");
        }
    }
}
