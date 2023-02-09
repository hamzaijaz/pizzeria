using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Queries
{
    public class GetAllPizzasQuery : IRequest<List<PizzaDto>>
    {
        public class GetAllPizzasHandler : IRequestHandler<GetAllPizzasQuery, List<PizzaDto>>
        {
            private readonly IPizzaRepository _pizzaRepository;

            public GetAllPizzasHandler(IPizzaRepository pizzaRepository)
            {
                Guard.Against.Null(pizzaRepository, nameof(pizzaRepository));
                _pizzaRepository = pizzaRepository;
            }

            public async Task<List<PizzaDto>> Handle(GetAllPizzasQuery query, CancellationToken cancellationToken)
            {
                return await _pizzaRepository.GetAllPizzasAsync();
            }
        }
    }
}
