using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Commands
{
    public class DeletePizzaCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeletePizzaCommandHandler : IRequestHandler<DeletePizzaCommand, int>
        {
            private readonly IPizzaRepository _pizzaRepository;

            public DeletePizzaCommandHandler(IPizzaRepository pizzaRepository)
            {
                Guard.Against.Null(pizzaRepository, nameof(pizzaRepository));

                _pizzaRepository = pizzaRepository;
            }

            public async Task<int> Handle(DeletePizzaCommand command, CancellationToken cancellationToken)
            {
                return await _pizzaRepository.DeletePizzaAsync(command.Id);
            }
        }
    }
}
