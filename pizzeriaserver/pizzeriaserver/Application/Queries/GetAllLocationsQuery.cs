using Ardalis.GuardClauses;
using MediatR;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;

namespace pizzeriaserver.Application.Queries
{
    public class GetAllLocationsQuery : IRequest<List<LocationDto>>
    {
        public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, List<LocationDto>>
        {
            private readonly IAdminRepository _adminRepository;

            public GetAllLocationsQueryHandler(IAdminRepository adminRepository)
            {
                Guard.Against.Null(adminRepository, nameof(adminRepository));
                _adminRepository = adminRepository;
            }

            public async Task<List<LocationDto>> Handle(GetAllLocationsQuery query, CancellationToken cancellationToken)
            {
                return await _adminRepository.GetAllLocationsAsync();
            }
        }
    }
}
