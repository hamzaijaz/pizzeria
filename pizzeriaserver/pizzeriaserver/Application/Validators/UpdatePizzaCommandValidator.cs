using FluentValidation;
using pizzeriaserver.Application.Commands;

namespace pizzeriaserver.Application.Validators
{
    public class UpdatePizzaCommandValidator : AbstractValidator<UpdatePizzaCommand>
    {
        public UpdatePizzaCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotNull().WithMessage("Name must not be null")
                .NotEmpty().WithMessage("Name must not be empty")
                .GreaterThan(0).WithMessage("Pizza Id must be greater than zero");

            RuleFor(v => v.Name)
                .NotNull().WithMessage("Name must not be null")
                .NotEmpty().WithMessage("Name must not be empty");

            RuleFor(v => v.Description)
                .NotNull().WithMessage("Pizza description must not be null")
                .NotEmpty().WithMessage("Pizza description must not be empty");

            RuleFor(v => v.Price)
                .NotNull().WithMessage("Price must not be null")
                .NotEmpty().WithMessage("Price must not be empty")
                .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to zero");

            RuleFor(v => v.Location)
                .NotNull().WithMessage("Pizza location must not be null")
                .NotEmpty().WithMessage("Pizza location must not be empty");
        }
    }
}
