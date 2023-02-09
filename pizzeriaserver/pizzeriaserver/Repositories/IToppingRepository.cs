using pizzeriaserver.Application.Models;

namespace pizzeriaserver.Repositories
{
    public interface IToppingRepository
    {
        public Task<List<ToppingDto>> GetAllToppingsAsync();
        public Task<ToppingDto> GetToppingByIdAsync(int Id);
        public Task<ToppingDto> AddToppingAsync(ToppingDto toppingDetails);
        public Task<ToppingDto> UpdateToppingAsync(ToppingDto toppingDetails);
        public Task<int> DeleteToppingAsync(int id);
    }
}
