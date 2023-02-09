using pizzeriaserver.Application.Models;

namespace pizzeriaserver.Repositories
{
    public interface IPizzaRepository
    {
        public Task<List<PizzaDto>> GetAllPizzasAsync();
        public Task<PizzaDto> GetPizzaByIdAsync(int Id);
        public Task<PizzaDto> AddPizzaAsync(PizzaDto pizzaDetails);
        public Task<PizzaDto> UpdatePizzaAsync(PizzaDto pizzaDetails);
        public Task<int> DeletePizzaAsync(int id);
    }
}
