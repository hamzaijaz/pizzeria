using FluentValidation;
using pizzeriaserver.Application.Commands;

namespace pizzeriaserver.Application.Validators
{
    public class AddPizzaToLocationCommandValidator : AbstractValidator<AddPizzaToLocationCommand>
    {
        public AddPizzaToLocationCommandValidator()
        {
            RuleFor(v => v.PizzaId)
                .NotNull().WithMessage("PizzaId must not be null")
                .NotEmpty().WithMessage("PizzaId must not be empty")
                .GreaterThan(0).WithMessage("PizzaId must be greater than zero");

            RuleFor(v => v.LocationId)
                .NotNull().WithMessage("LocationId must not be null")
                .NotEmpty().WithMessage("LocationId must not be empty")
                .GreaterThan(0).WithMessage("LocationId must be greater than zero");

            RuleFor(v => v.Price)
                .NotNull().WithMessage("Price must not be null")
                .NotEmpty().WithMessage("Price must not be empty")
                .GreaterThan(0).WithMessage("Price must be greater than zero");
        }
    }
}
