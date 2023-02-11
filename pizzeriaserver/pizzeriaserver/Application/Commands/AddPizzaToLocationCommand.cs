using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Commands
{
    public class AddPizzaToLocationCommand : IRequest<PizzaLocationDto>
    {
        public int PizzaId { get; set; }
        public int LocationId { get; set; }
        public decimal Price { get; set; }

        public class AddPizzaToLocationCommandHandler : IRequestHandler<AddPizzaToLocationCommand, PizzaLocationDto>
        {
            private readonly IAdminRepository _adminRepository;

            public AddPizzaToLocationCommandHandler(IAdminRepository adminRepository)
            {
                Guard.Against.Null(adminRepository, nameof(adminRepository));
                _adminRepository = adminRepository;
            }

            public async Task<PizzaLocationDto> Handle(AddPizzaToLocationCommand command, CancellationToken cancellationToken)
            {
                return await _adminRepository.AddPizzaLocationAsync(command.PizzaId, command.LocationId, command.Price);
            }
        }
    }
}
