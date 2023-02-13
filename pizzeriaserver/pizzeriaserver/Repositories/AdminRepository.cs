using Ardalis.GuardClauses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pizzeriaserver.Application.Common.Exceptions;
using pizzeriaserver.Application.Common.Interfaces;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Data.Entities;
using NotFoundException = pizzeriaserver.Application.Common.Exceptions.NotFoundException;

namespace pizzeriaserver.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AdminRepository(IApplicationDbContext dbContext, IMapper mapper)
        {
            Guard.Against.Null(dbContext, nameof(dbContext));
            Guard.Against.Null(mapper, nameof(mapper));

            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<LocationDto> AddLocationAsync(LocationDto locationDetails)
        {
            var existingLocation = await _dbContext.Locations.FirstOrDefaultAsync(l => l.Name == locationDetails.Name);
            if(existingLocation != null) 
            {
                throw new DuplicateItemException(nameof(Location.Name) + "(" + locationDetails.Name + ")");
            }

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

        public async Task<PizzaDto> AddPizzaAsync(AddPizzaDto pizzaDetails)
        {
            var pizza = _mapper.Map<Pizza>(pizzaDetails);
            var result = _dbContext.Pizzas.Add(pizza);
            await _dbContext.SaveChangesAsync();

            var pizzaLocation = pizzaDetails.LocationIds;
            foreach (var locationId in pizzaLocation)
            {
                _dbContext.PizzaLocations.Add(new PizzaLocation { PizzaId = result.Entity.Id, LocationId = locationId, Price = pizzaDetails.Price });
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PizzaDto>(result.Entity);
        }

        public async Task<int> DeletePizzaAsync(int pizzaId, int locationId)
        {
            var pizzaToDelete = await _dbContext.Pizzas.Where(x => x.Id == pizzaId).FirstOrDefaultAsync();
            if (pizzaToDelete == null)
            {
                throw new NotFoundException(nameof(Pizza), pizzaId);
            }

            var pizzaLocationToDelete = await _dbContext.PizzaLocations.FirstOrDefaultAsync(pl => pl.PizzaId == pizzaId && pl.LocationId == locationId);
            if (pizzaLocationToDelete == null)
            {
                throw new NotFoundException(nameof(PizzaLocation), locationId);
            }

            //remove this pizza from pizza table if it is being removed even from the last location (it is not being served in any location)
            var isThisPizzaOnlyInThisLocation = (await _dbContext.PizzaLocations.Where(pl => pl.PizzaId == pizzaId).CountAsync()) < 2;

            _dbContext.PizzaLocations.Remove(pizzaLocationToDelete);
            if (isThisPizzaOnlyInThisLocation)
            {
                _dbContext.Pizzas.Remove(pizzaToDelete);
            }

            await _dbContext.SaveChangesAsync();
            return pizzaToDelete.Id;
        }

        public async Task<PizzaDto> UpdatePizzaAsync(UpdatePizzaDto pizzaDetails)
        {
            var pizzaToUpdate = await _dbContext.Pizzas.Where(p => p.Id == pizzaDetails.Id).FirstOrDefaultAsync();
            if (pizzaToUpdate == null)
            {
                throw new NotFoundException(nameof(Pizza), pizzaDetails.Id);
            }

            pizzaToUpdate.Name = pizzaDetails.Name;
            pizzaToUpdate.Description = pizzaDetails.Description;

            var pizzaLocationToUpdate = await _dbContext.PizzaLocations.Where(pl => pl.PizzaId == pizzaDetails.Id && pl.LocationId == pizzaDetails.LocationId).FirstOrDefaultAsync();
            if (pizzaToUpdate == null)
            {
                throw new NotFoundException(nameof(PizzaLocation), pizzaDetails.LocationId);
            }

            pizzaLocationToUpdate.Price = pizzaDetails.Price;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<PizzaDto>(pizzaToUpdate);
        }

        public async Task<ToppingDto> AddToppingAsync(ToppingDto toppingDetails)
        {
            var topping = _mapper.Map<Topping>(toppingDetails);
            var result = _dbContext.Toppings.Add(topping);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ToppingDto>(result.Entity);
        }

        public async Task<int> DeleteToppingAsync(int id)
        {
            var toppingToDelete = await _dbContext.Toppings.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (toppingToDelete == null)
            {
                throw new NotFoundException(nameof(Topping), id);
            }

            _dbContext.Toppings.Remove(toppingToDelete);
            await _dbContext.SaveChangesAsync();
            return toppingToDelete.Id;
        }

        public async Task<ToppingDto> UpdateToppingAsync(ToppingDto toppingDetails)
        {
            var toppingToUpdate = await _dbContext.Toppings.Where(p => p.Id == toppingDetails.Id).FirstOrDefaultAsync();
            if (toppingToUpdate == null)
            {
                throw new NotFoundException(nameof(Topping), toppingDetails.Id);
            }

            toppingToUpdate.Name = toppingDetails.Name;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ToppingDto>(toppingToUpdate);
        }
    }
}
