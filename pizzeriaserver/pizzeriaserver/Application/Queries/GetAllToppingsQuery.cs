using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Queries
{
    public class GetAllToppingsQuery : IRequest<List<ToppingDto>>
    {
        public class GetAllToppingsQueryHandler : IRequestHandler<GetAllToppingsQuery, List<ToppingDto>>
        {
            private readonly IToppingRepository _toppingRepository;

            public GetAllToppingsQueryHandler(IToppingRepository toppingRepository)
            {
                Guard.Against.Null(toppingRepository, nameof(toppingRepository));
                _toppingRepository = toppingRepository;
            }

            public async Task<List<ToppingDto>> Handle(GetAllToppingsQuery query, CancellationToken cancellationToken)
            {
                return await _toppingRepository.GetAllToppingsAsync();
            }
        }
    }
}
