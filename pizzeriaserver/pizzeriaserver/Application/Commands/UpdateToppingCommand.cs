using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Commands
{
    public class UpdateToppingCommand : IRequest<ToppingDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateToppingCommandHandler : IRequestHandler<UpdateToppingCommand, ToppingDto>
        {
            private readonly IToppingRepository _toppingRepository;

            public UpdateToppingCommandHandler(IToppingRepository toppingRepository)
            {
                Guard.Against.Null(toppingRepository, nameof(toppingRepository));

                _toppingRepository = toppingRepository;
            }

            public async Task<ToppingDto> Handle(UpdateToppingCommand command, CancellationToken cancellationToken)
            {
                var topping = new ToppingDto()
                {
                    Id = command.Id,
                    Name = command.Name
                };

                return await _toppingRepository.UpdateToppingAsync(topping);
            }
        }
    }
}
