using Ardalis.GuardClauses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Data;
using pizzeriaserver.Data.Entities;
using NotFoundException = pizzeriaserver.Application.Common.Exceptions.NotFoundException;

namespace pizzeriaserver.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PizzaRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            Guard.Against.Null(dbContext, nameof(dbContext));
            Guard.Against.Null(mapper, nameof(mapper));

            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PizzaDto> AddPizzaAsync(PizzaDto pizzaDetails)
        {
            var pizza = _mapper.Map<Pizza>(pizzaDetails);
            var result = _dbContext.Pizzas.Add(pizza);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PizzaDto>(result.Entity);
        }

        public async Task<int> DeletePizzaAsync(int id)
        {
            var pizzaToDelete = await _dbContext.Pizzas.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (pizzaToDelete == null)
            {
                throw new NotFoundException(nameof(Pizza), id);
            }

            _dbContext.Pizzas.Remove(pizzaToDelete);
            await _dbContext.SaveChangesAsync();
            return pizzaToDelete.Id;
        }

        public async Task<PizzaDto> GetPizzaByIdAsync(int id)
        {
            var pizza = await _dbContext.Pizzas.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (pizza == null)
            {
                throw new NotFoundException(nameof(Pizza), id);
            }

            return _mapper.Map<PizzaDto>(pizza);
        }

        public async Task<List<PizzaDto>> GetAllPizzasAsync()
        {
            var pizzas = await _dbContext.Pizzas.AsNoTracking().ToListAsync();
            var response = pizzas.Select(pizza => _mapper.Map<PizzaDto>(pizza)).ToList();
            return response;
        }

        public async Task<PizzaDto> UpdatePizzaAsync(PizzaDto pizzaDetails)
        {
            var pizzaToUpdate = await _dbContext.Pizzas.Where(p => p.Id == pizzaDetails.Id).FirstOrDefaultAsync();
            if(pizzaToUpdate == null)
            {
                throw new NotFoundException(nameof(Pizza), pizzaDetails.Id);
            }

            pizzaToUpdate.Name= pizzaDetails.Name;
            pizzaToUpdate.Description= pizzaDetails.Description;
            pizzaToUpdate.Location= pizzaDetails.Location;
            pizzaToUpdate.Price= pizzaDetails.Price;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<PizzaDto>(pizzaToUpdate);
        }
    }
}
