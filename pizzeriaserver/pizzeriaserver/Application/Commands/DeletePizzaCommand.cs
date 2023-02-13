using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Commands
{
    public class DeletePizzaCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int PizzaLocationId { get; set; }

        public class DeletePizzaCommandHandler : IRequestHandler<DeletePizzaCommand, int>
        {
            private readonly IAdminRepository _adminRepository;

            public DeletePizzaCommandHandler(IAdminRepository adminRepository)
            {
                Guard.Against.Null(adminRepository, nameof(adminRepository));
                _adminRepository = adminRepository;
            }

            public async Task<int> Handle(DeletePizzaCommand command, CancellationToken cancellationToken)
            {
                return await _adminRepository.DeletePizzaAsync(command.Id, command.PizzaLocationId);
            }
        }
    }
}
