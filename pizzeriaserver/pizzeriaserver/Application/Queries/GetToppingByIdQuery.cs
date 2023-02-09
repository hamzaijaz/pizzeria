using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Queries
{
    public class GetToppingByIdQuery : IRequest<ToppingDto>
    {
        public int Id { get; set; }

        public class GetToppingByIdQueryHandler : IRequestHandler<GetToppingByIdQuery, ToppingDto>
        {
            private readonly IToppingRepository _toppingRepository;

            public GetToppingByIdQueryHandler(IToppingRepository toppingRepository)
            {
                Guard.Against.Null(toppingRepository, nameof(toppingRepository));
                _toppingRepository = toppingRepository;
            }

            public async Task<ToppingDto> Handle(GetToppingByIdQuery request, CancellationToken cancellationToken)
            {
                return await _toppingRepository.GetToppingByIdAsync(request.Id);
            }
        }
    }
}
