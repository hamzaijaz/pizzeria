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
            private readonly IToppingRepository _toppingRepository;

            public DeleteToppingCommandHandler(IToppingRepository toppingRepository)
            {
                Guard.Against.Null(toppingRepository, nameof(toppingRepository));

                _toppingRepository = toppingRepository;
            }

            public async Task<int> Handle(DeleteToppingCommand command, CancellationToken cancellationToken)
            {
                return await _toppingRepository.DeleteToppingAsync(command.Id);
            }
        }
    }
}
