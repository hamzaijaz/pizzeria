using MediatR;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Queries
{
    public class GetPizzaByIdQuery : IRequest<PizzaDto>
    {
        public int Id { get; set; }

        public class GetPizzaByIdQueryHandler : IRequestHandler<GetPizzaByIdQuery, PizzaDto>
        {
            private readonly IPizzaRepository _pizzaRepository;

            public GetPizzaByIdQueryHandler(IPizzaRepository pizzaRepository)
            {
                _pizzaRepository = pizzaRepository;
            }

            public async Task<PizzaDto> Handle(GetPizzaByIdQuery request, CancellationToken cancellationToken)
            {
                return await _pizzaRepository.GetPizzaByIdAsync(request.Id);
            }
        }
    }
}
