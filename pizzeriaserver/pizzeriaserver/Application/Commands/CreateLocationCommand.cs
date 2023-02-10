using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Commands
{
    public class CreateLocationCommand : IRequest<LocationDto>
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, LocationDto>
        {
            private readonly IAdminRepository _adminRepository;

            public CreateLocationCommandHandler(IAdminRepository adminRepository)
            {
                Guard.Against.Null(adminRepository, nameof(adminRepository));
                _adminRepository = adminRepository;
            }

            public async Task<LocationDto> Handle(CreateLocationCommand command, CancellationToken cancellation)
            {
                var location = new LocationDto()
                {
                    Name = command.Name,
                    Address = command.Address
                };

                return await _adminRepository.AddLocationAsync(location);
            }
        }
    }
}
