using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Commands
{
    public class UpdatePizzaCommand : IRequest<PizzaDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int LocationId { get; set; }

        public class UpdatePizzaCommandHandler : IRequestHandler<UpdatePizzaCommand, PizzaDto>
        {
            private readonly IAdminRepository _adminRepository;

            public UpdatePizzaCommandHandler(IAdminRepository adminRepository)
            {
                Guard.Against.Null(adminRepository, nameof(adminRepository));

                _adminRepository = adminRepository;
            }

            public async Task<PizzaDto> Handle(UpdatePizzaCommand command, CancellationToken cancellationToken)
            {
                var pizza = new UpdatePizzaDto()
                {
                    Id = command.Id,
                    Name = command.Name,
                    Description = command.Description,
                    Price = command.Price,
                    LocationId = command.LocationId,
                };

                return await _adminRepository.UpdatePizzaAsync(pizza);
            }
        }
    }
}
