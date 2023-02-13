using Ardalis.GuardClauses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pizzeriaserver.Application.Common.Interfaces;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Data.Entities;
using NotFoundException = pizzeriaserver.Application.Common.Exceptions.NotFoundException;

namespace pizzeriaserver.Repositories
{
    public class ToppingRepository : IToppingRepository
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ToppingRepository(IApplicationDbContext dbContext, IMapper mapper)
        {
            Guard.Against.Null(dbContext, nameof(dbContext));
            Guard.Against.Null(mapper, nameof(mapper));

            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ToppingDto> GetToppingByIdAsync(int id)
        {
            var topping = await _dbContext.Toppings.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (topping == null)
            {
                throw new NotFoundException(nameof(Topping), id);
            }

            return _mapper.Map<ToppingDto>(topping);
        }

        public async Task<List<ToppingDto>> GetAllToppingsAsync()
        {
            var toppings = await _dbContext.Toppings.AsNoTracking().ToListAsync();
            var response = toppings.Select(topping => _mapper.Map<ToppingDto>(topping)).ToList();
            return response;
        }
    }
}
