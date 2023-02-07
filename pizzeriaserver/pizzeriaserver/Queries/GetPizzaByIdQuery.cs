using MediatR;
using pizzeriaserver.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Queries
{
    public class GetPizzaByIdQuery : IRequest<Pizza>
    {
        public int Id { get; set; }

        public class GetPizzaByIdQueryHandler : IRequestHandler<GetPizzaByIdQuery, Pizza>
        {
            private readonly IPizzaRepository _pizzaRepository;

            public GetPizzaByIdQueryHandler(IPizzaRepository pizzaRepository)
            {
                _pizzaRepository = pizzaRepository;
            }

            public async Task<Pizza> Handle(GetPizzaByIdQuery request, CancellationToken cancellationToken)
            {
                return await _pizzaRepository.GetPizzaByIdAsync(request.Id);
            }
        }
    }
}
