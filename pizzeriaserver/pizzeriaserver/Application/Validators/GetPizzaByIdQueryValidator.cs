using FluentValidation;
using pizzeriaserver.Application.Queries;

namespace pizzeriaserver.Application.Validators
{
    public class GetPizzaByIdQueryValidator : AbstractValidator<GetPizzaByIdQuery>
    {
        public GetPizzaByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotNull().WithMessage("Pizza Id must not be null")
                .NotEmpty().WithMessage("Pizza Id must not be empty")
                .GreaterThan(0).WithMessage("Pizza Id must be greater than zero");
        }
    }
}
