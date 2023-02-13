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
            private readonly IAdminRepository _adminRepository;

            public CreateToppingCommandHandler(IAdminRepository adminRepository)
            {
                Guard.Against.Null(adminRepository, nameof(adminRepository));
                _adminRepository = adminRepository;
            }

            public async Task<ToppingDto> Handle(CreateToppingCommand command, CancellationToken cancellation)
            {
                var topping = new ToppingDto()
                {
                    Name = command.Name
                };

                return await _adminRepository.AddToppingAsync(topping);
            }
        }
    }
}
