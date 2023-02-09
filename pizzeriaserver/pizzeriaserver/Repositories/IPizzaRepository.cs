using pizzeriaserver.Application.Models;

namespace pizzeriaserver.Repositories
{
    public interface IPizzaRepository
    {
        public Task<List<PizzaDto>> GetAllPizzasAsync();
        public Task<PizzaDto> GetPizzaByIdAsync(int Id);
        public Task<PizzaDto> AddPizzaAsync(PizzaDto studentDetails);
        public Task<PizzaDto> UpdatePizzaAsync(PizzaDto studentDetails);
        public Task<int> DeletePizzaAsync(int id);
    }
}
