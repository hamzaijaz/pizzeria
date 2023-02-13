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
            private readonly IAdminRepository _adminRepository;

            public UpdateToppingCommandHandler(IAdminRepository adminRepository)
            {
                Guard.Against.Null(adminRepository, nameof(adminRepository));

                _adminRepository = adminRepository;
            }

            public async Task<ToppingDto> Handle(UpdateToppingCommand command, CancellationToken cancellationToken)
            {
                var topping = new ToppingDto()
                {
                    Id = command.Id,
                    Name = command.Name
                };

                return await _adminRepository.UpdateToppingAsync(topping);
            }
        }
    }
}
