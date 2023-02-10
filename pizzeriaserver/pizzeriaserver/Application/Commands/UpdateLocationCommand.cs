using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Commands
{
    public class UpdateLocationCommand : IRequest<LocationDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, LocationDto>
        {
            private readonly IAdminRepository _adminRepository;

            public UpdateLocationCommandHandler(IAdminRepository adminRepository)
            {
                Guard.Against.Null(adminRepository, nameof(adminRepository));

                _adminRepository = adminRepository;
            }

            public async Task<LocationDto> Handle(UpdateLocationCommand command, CancellationToken cancellationToken)
            {
                var location = new LocationDto()
                {
                    Id = command.Id,
                    Name = command.Name,
                    Address = command.Address
                };

                return await _adminRepository.UpdateLocationAsync(location);
            }
        }
    }
}
