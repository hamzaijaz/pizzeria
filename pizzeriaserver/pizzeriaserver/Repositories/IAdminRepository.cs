using pizzeriaserver.Application.Models;

namespace pizzeriaserver.Repositories
{
    public interface IAdminRepository
    {
        //Locations
        public Task<List<LocationDto>> GetAllLocationsAsync();
        public Task<LocationDto> AddLocationAsync(LocationDto locationDetails);
        public Task<LocationDto> UpdateLocationAsync(LocationDto locationDetails);
        public Task<int> DeleteLocationAsync(int id);

        //Pizzas
        public Task<PizzaLocationDto> AddPizzaLocationAsync(int pizzaId, int locationId, decimal price);
        public Task<PizzaDto> AddPizzaAsync(AddPizzaDto pizzaDetails);
        public Task<int> DeletePizzaAsync(int pizzaId, int pizzaLocationId);
        public Task<PizzaDto> UpdatePizzaAsync(UpdatePizzaDto pizzaDetails);

        //Toppings
        public Task<ToppingDto> AddToppingAsync(ToppingDto toppingDetails);
        public Task<ToppingDto> UpdateToppingAsync(ToppingDto toppingDetails);
        public Task<int> DeleteToppingAsync(int id);
    }
}
