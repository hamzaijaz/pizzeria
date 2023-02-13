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

        public async Task<List<PizzaDto>> GetPizzasForLocationAsync(int locationId)
        {
            var pizzas = await _dbContext.Pizzas
                .Include(p => p.PizzaLocations)
                .Where(p => p.PizzaLocations.Any(pl => pl.LocationId == locationId))
                .Select(pd => new PizzaDto 
                { 
                    Id = pd.Id, 
                    Description = pd.Description, 
                    Name = pd.Name, 
                    Price = pd.PizzaLocations.FirstOrDefault(pl => pl.PizzaId == pd.Id && pl.LocationId == locationId).Price
                })
                .ToListAsync();

            var response = pizzas.Select(pizza => _mapper.Map<PizzaDto>(pizza)).ToList();
            return response;
        }
    }
}
