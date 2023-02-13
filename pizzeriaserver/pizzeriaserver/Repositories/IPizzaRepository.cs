using pizzeriaserver.Application.Models;

namespace pizzeriaserver.Repositories
{
    public interface IPizzaRepository
    {
        public Task<List<PizzaDto>> GetAllPizzasAsync();
        public Task<List<PizzaDto>> GetPizzasForLocationAsync(int locationId);
        public Task<PizzaDto> GetPizzaByIdAsync(int Id);
        public Task<PizzaDto> AddPizzaAsync(AddPizzaDto pizzaDetails);
        public Task<PizzaDto> UpdatePizzaAsync(UpdatePizzaDto pizzaDetails);
        public Task<int> DeletePizzaAsync(int id);
    }
}
