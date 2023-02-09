using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Commands
{
    public class CreateToppingCommand : IRequest<ToppingDto>
    {
        public string Name { get; set; }

        public class CreateToppingCommandHandler : IRequestHandler<CreateToppingCommand, ToppingDto>
        {
            private readonly IToppingRepository _toppingRepository;

            public CreateToppingCommandHandler(IToppingRepository toppingRepository)
            {
                Guard.Against.Null(toppingRepository, nameof(toppingRepository));
                _toppingRepository = toppingRepository;
            }

            public async Task<ToppingDto> Handle(CreateToppingCommand command, CancellationToken cancellation)
            {
                var topping = new ToppingDto()
                {
                    Name = command.Name
                };

                return await _toppingRepository.AddToppingAsync(topping);
            }
        }
    }
}
