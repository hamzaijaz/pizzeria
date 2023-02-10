using Ardalis.GuardClauses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Data;
using pizzeriaserver.Data.Entities;
using NotFoundException = pizzeriaserver.Application.Common.Exceptions.NotFoundException;

namespace pizzeriaserver.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AdminRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            Guard.Against.Null(dbContext, nameof(dbContext));
            Guard.Against.Null(mapper, nameof(mapper));

            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<LocationDto> AddLocationAsync(LocationDto locationDetails)
        {
            var location = _mapper.Map<Location>(locationDetails);
            var result = _dbContext.Locations.Add(location);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<LocationDto>(result.Entity);
        }

        public async Task<int> DeleteLocationAsync(int id)
        {
            var locationToDelete = await _dbContext.Locations.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (locationToDelete == null)
            {
                throw new NotFoundException(nameof(Location), id);
            }

            _dbContext.Locations.Remove(locationToDelete);
            await _dbContext.SaveChangesAsync();
            return locationToDelete.Id;
        }

        public async Task<List<LocationDto>> GetAllLocationsAsync()
        {
            var locations = await _dbContext.Locations.AsNoTracking().ToListAsync();
            var response = locations.Select(location => _mapper.Map<LocationDto>(location)).ToList();
            return response;
        }

        public async Task<LocationDto> UpdateLocationAsync(LocationDto locationDetails)
        {
            var locationToUpdate = await _dbContext.Locations.Where(p => p.Id == locationDetails.Id).FirstOrDefaultAsync();
            if (locationToUpdate == null)
            {
                throw new NotFoundException(nameof(Location), locationDetails.Id);
            }

            locationToUpdate.Name = locationDetails.Name;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<LocationDto>(locationToUpdate);
        }
    }
}
