using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Queries
{
    public class GetPizzasForLocationQuery : IRequest<List<PizzaDto>>
    {
        public int LocationId { get; set; }
        public class GetPizzasForLocationQueryHandler : IRequestHandler<GetPizzasForLocationQuery, List<PizzaDto>>
        {
            private readonly IPizzaRepository _pizzaRepository;

            public GetPizzasForLocationQueryHandler(IPizzaRepository pizzaRepository)
            {
                Guard.Against.Null(pizzaRepository, nameof(pizzaRepository));
                _pizzaRepository = pizzaRepository;
            }

            public async Task<List<PizzaDto>> Handle(GetPizzasForLocationQuery query, CancellationToken cancellationToken)
            {
                return await _pizzaRepository.GetPizzasForLocationAsync(query.LocationId);
            }
        }
    }
}
