using FluentValidation;
using pizzeriaserver.Application.Commands;

namespace pizzeriaserver.Application.Validators
{
    public class DeleteToppingCommandValidator : AbstractValidator<DeleteToppingCommand>
    {
        public DeleteToppingCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotNull().WithMessage("Topping Id must not be null")
                .NotEmpty().WithMessage("Topping Id must not be empty")
                .GreaterThan(0).WithMessage("Topping Id must be greater than zero");
        }
    }
}
