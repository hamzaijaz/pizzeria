﻿using Ardalis.GuardClauses;
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

            var pizzaLocationsToDelete = await _dbContext.PizzaLocations.Where(pl => pl.LocationId == id).ToListAsync();

            _dbContext.PizzaLocations.RemoveRange(pizzaLocationsToDelete);
            _dbContext.Locations.Remove(locationToDelete);
            await _dbContext.SaveChangesAsync();
            return locationToDelete.Id;
        }

        public async Task<List<LocationDto>> GetAllLocationsAsync()
        {
            var locations = await _dbContext.Locations.AsNoTracking().OrderBy(l => l.Name).ToListAsync();
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
            locationToUpdate.Address = locationDetails.Address;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<LocationDto>(locationToUpdate);
        }

        public async Task<PizzaLocationDto> AddPizzaLocationAsync(int pizzaId, int locationId, decimal price)
        {
            var pizza = await _dbContext.Pizzas.FirstOrDefaultAsync(p => p.Id == pizzaId);
            if (pizza == null)
            {
                throw new NotFoundException(nameof(Pizza), pizzaId);
            }

            var location = await _dbContext.Locations.FirstOrDefaultAsync(l => l.Id == locationId);
            if (location == null)
            {
                throw new NotFoundException(nameof(Location), locationId);
            }

            var pizzaLocation = new PizzaLocation
            {
                PizzaId = pizzaId,
                LocationId = locationId,
                Price = price
            };

            var result = _dbContext.PizzaLocations.Add(pizzaLocation);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<PizzaLocationDto>(result.Entity);
        }
    }
}
