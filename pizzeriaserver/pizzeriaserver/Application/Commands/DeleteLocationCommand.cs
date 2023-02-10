using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Commands
{
    public class DeleteLocationCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, int>
        {
            private readonly IAdminRepository _adminRepository;

            public DeleteLocationCommandHandler(IAdminRepository adminRepository)
            {
                Guard.Against.Null(adminRepository, nameof(adminRepository));

                _adminRepository = adminRepository;
            }

            public async Task<int> Handle(DeleteLocationCommand command, CancellationToken cancellationToken)
            {
                return await _adminRepository.DeleteLocationAsync(command.Id);
            }
        }
    }
}
