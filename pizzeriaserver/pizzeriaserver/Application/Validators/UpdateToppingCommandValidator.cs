using FluentValidation;
using pizzeriaserver.Application.Commands;

namespace pizzeriaserver.Application.Validators
{
    public class UpdateToppingCommandValidator : AbstractValidator<UpdateToppingCommand>
    {
        public UpdateToppingCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotNull().WithMessage("Topping name must not be null")
                .NotEmpty().WithMessage("Topping name must not be empty");

            RuleFor(v => v.Id)
                .NotNull().WithMessage("Topping Id must not be null")
                .NotEmpty().WithMessage("Topping Id must not be empty")
                .GreaterThan(0).WithMessage("Topping Id must be greater than zero");
        }
    }
}
