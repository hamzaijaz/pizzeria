using FluentValidation;
using pizzeriaserver.Application.Commands;

namespace pizzeriaserver.Application.Validators
{
    public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
    {
        public UpdateLocationCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotNull().WithMessage("Name must not be null")
                .NotEmpty().WithMessage("Name must not be empty")
                .GreaterThan(0).WithMessage("Location Id must be greater than zero");

            RuleFor(v => v.Name)
                .NotNull().WithMessage("Name must not be null")
                .NotEmpty().WithMessage("Name must not be empty");

            RuleFor(v => v.Address)
                .NotNull().WithMessage("Address must not be null")
                .NotEmpty().WithMessage("Address must not be empty");
        }
    }
}
