using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Commands
{
    public class DeleteToppingCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteToppingCommandHandler : IRequestHandler<DeleteToppingCommand, int>
        {
            private readonly IAdminRepository _adminRepository;

            public DeleteToppingCommandHandler(IAdminRepository adminRepository)
            {
                Guard.Against.Null(adminRepository, nameof(adminRepository));

                _adminRepository = adminRepository;
            }

            public async Task<int> Handle(DeleteToppingCommand command, CancellationToken cancellationToken)
            {
                return await _adminRepository.DeleteToppingAsync(command.Id);
            }
        }
    }
}
