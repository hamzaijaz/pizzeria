using pizzeriaserver.Models;

namespace pizzeriaserver.Repositories
{
    public interface IPizzaRepository
    {
        public Task<List<Pizza>> GetAllPizzasAsync();
        public Task<Pizza> GetPizzaByIdAsync(int Id);
        public Task<Pizza> AddPizzaAsync(Pizza studentDetails);
        public Task<int> UpdatePizzaAsync(Pizza studentDetails);
        public Task<int> DeletePizzaAsync(int Id);
    }
}
