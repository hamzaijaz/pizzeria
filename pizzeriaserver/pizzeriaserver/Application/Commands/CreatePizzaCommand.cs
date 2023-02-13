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
        public decimal Price { get; set; }
        public List<int> LocationIds { get; set; }

        public class CreatePizzaCommandHandler : IRequestHandler<CreatePizzaCommand, PizzaDto>
        {
            private readonly IAdminRepository _adminRepository;

            public CreatePizzaCommandHandler(IAdminRepository adminRepository)
            {
                Guard.Against.Null(adminRepository, nameof(adminRepository));
                _adminRepository = adminRepository;
            }

            public async Task<PizzaDto> Handle(CreatePizzaCommand command, CancellationToken cancellation)
            {
                var pizza = new AddPizzaDto()
                {
                    Name = command.Name,
                    Description = command.Description,
                    Price = command.Price,
                    LocationIds = command.LocationIds,
                };

                return await _adminRepository.AddPizzaAsync(pizza);
            }
        }
    }
}
