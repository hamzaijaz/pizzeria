using pizzeriaserver.Application.Models;

namespace pizzeriaserver.Repositories
{
    public interface IPizzaRepository
    {
        public Task<List<PizzaDto>> GetAllPizzasAsync();
        public Task<List<PizzaDto>> GetPizzasForLocationAsync(int locationId);
        public Task<PizzaDto> GetPizzaByIdAsync(int Id);
    }
}
