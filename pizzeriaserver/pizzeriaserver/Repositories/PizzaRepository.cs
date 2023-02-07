using Microsoft.EntityFrameworkCore;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Data;

namespace pizzeriaserver.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly DbContextClass _dbContext;

        public PizzaRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PizzaDto> AddPizzaAsync(PizzaDto pizzaDetails)
        {
            var result = _dbContext.Pizzas.Add(pizzaDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeletePizzaAsync(int Id)
        {
            var filteredData = _dbContext.Pizzas.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Pizzas.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<PizzaDto> GetPizzaByIdAsync(int Id)
        {
            return await _dbContext.Pizzas.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<PizzaDto>> GetAllPizzasAsync()
        {
            return await _dbContext.Pizzas.ToListAsync();
        }

        public async Task<int> UpdatePizzaAsync(PizzaDto pizzaDetails)
        {
            _dbContext.Pizzas.Update(pizzaDetails);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
