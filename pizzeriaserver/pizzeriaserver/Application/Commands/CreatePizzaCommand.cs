using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Commands
{
    public class CreatePizzaCommand : IRequest<PizzaDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public class CreatePizzaCommandHandler : IRequestHandler<CreatePizzaCommand, PizzaDto>
        {
            private readonly IPizzaRepository _pizzaRepository;

            public CreatePizzaCommandHandler(IPizzaRepository pizzaRepository)
            {
                Guard.Against.Null(pizzaRepository, nameof(pizzaRepository));
                _pizzaRepository = pizzaRepository;
            }

            public async Task<PizzaDto> Handle(CreatePizzaCommand command, CancellationToken cancellation)
            {
                var pizza = new PizzaDto()
                {
                    Name = command.Name,
                    Description = command.Description
                };

                return await _pizzaRepository.AddPizzaAsync(pizza);
            }
        }
    }
}
