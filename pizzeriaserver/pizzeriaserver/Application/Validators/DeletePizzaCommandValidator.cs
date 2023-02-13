using FluentValidation;
using pizzeriaserver.Application.Commands;

namespace pizzeriaserver.Application.Validators
{
    public class DeletePizzaCommandValidator : AbstractValidator<DeletePizzaCommand>
    {
        public DeletePizzaCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotNull().WithMessage("Id must not be null")
                .NotEmpty().WithMessage("Id must not be empty")
                .GreaterThan(0).WithMessage("Id must be greater than zero");

            RuleFor(v => v.PizzaLocationId)
                .NotNull().WithMessage("Location Id must not be null")
                .NotEmpty().WithMessage("Location Id must not be empty")
                .GreaterThan(0).WithMessage("Location Id must be greater than zero");
        }
    }
}
