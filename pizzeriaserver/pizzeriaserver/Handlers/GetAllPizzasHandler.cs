using MediatR;
using pizzeriaserver.Models;
using pizzeriaserver.Queries;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Handlers
{
    public class GetAllPizzasHandler : IRequestHandler<GetAllPizzasQuery, List<Pizza>>
    {
        private readonly IPizzaRepository _pizzaRepository;

        public GetAllPizzasHandler(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public async Task<List<Pizza>> Handle(GetAllPizzasQuery query, CancellationToken cancellationToken)
        {
            return await _pizzaRepository.GetAllPizzasAsync();
        }
    }
}
