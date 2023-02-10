using FluentValidation;
using pizzeriaserver.Application.Queries;

namespace pizzeriaserver.Application.Validators
{
    public class GetToppingByIdQueryValidator : AbstractValidator<GetToppingByIdQuery>
    {
        public GetToppingByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotNull().WithMessage("Topping Id must not be null")
                .NotEmpty().WithMessage("Topping Id must not be empty")
                .GreaterThan(0).WithMessage("Topping Id must be greater than zero");
        }
    }
}
