using pizzeriaserver.Application.Models;

namespace pizzeriaserver.Repositories
{
    public interface IAdminRepository
    {
        public Task<List<LocationDto>> GetAllLocationsAsync();
        public Task<LocationDto> AddLocationAsync(LocationDto locationDetails);
        public Task<LocationDto> UpdateLocationAsync(LocationDto locationDetails);
        public Task<int> DeleteLocationAsync(int id);
        public Task<PizzaLocationDto> AddPizzaLocationAsync(int pizzaId, int locationId, decimal price);
        public Task<PizzaDto> AddPizzaAsync(AddPizzaDto pizzaDetails);
        public Task<int> DeletePizzaAsync(int pizzaId, int pizzaLocationId);
        public Task<PizzaDto> UpdatePizzaAsync(UpdatePizzaDto pizzaDetails);
    }
}
