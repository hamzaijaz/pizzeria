using FluentValidation;
using pizzeriaserver.Application.Queries;

namespace pizzeriaserver.Application.Validators
{
    public class GetPizzasForLocationQueryValidator : AbstractValidator<GetPizzasForLocationQuery>
    {
        public GetPizzasForLocationQueryValidator()
        {
            RuleFor(v => v.LocationId)
                .NotNull().WithMessage("Location Id must not be null")
                .NotEmpty().WithMessage("Location Id must not be empty")
                .GreaterThan(0).WithMessage("Location Id must be greater than zero");
        }
    }
}
