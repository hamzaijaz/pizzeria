using pizzeriaserver.Application.Models;

namespace pizzeriaserver.Repositories
{
    public interface IToppingRepository
    {
        public Task<List<ToppingDto>> GetAllToppingsAsync();
        public Task<ToppingDto> GetToppingByIdAsync(int Id);
    }
}
