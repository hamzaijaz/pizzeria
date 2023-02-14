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
            private readonly ILogger<CreateLocationCommand> _logger;

            public CreateLocationCommandHandler(IAdminRepository adminRepository, ILogger<CreateLocationCommand> logger)
            {
                Guard.Against.Null(adminRepository, nameof(adminRepository));
                _adminRepository = adminRepository;
                _logger = logger;
            }

            public async Task<LocationDto> Handle(CreateLocationCommand command, CancellationToken cancellation)
            {
                _logger.LogInformation($"Start running CreateLocationCommand with Name = {command.Name}, Address = {command.Address}");
                var location = new LocationDto()
                {
                    Name = command.Name,
                    Address = command.Address
                };

                var resp = await _adminRepository.AddLocationAsync(location);
                _logger.LogInformation("Finish running CreateLocationCommand");

                return resp;
            }
        }
    }
}
