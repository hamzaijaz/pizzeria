using Ardalis.GuardClauses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Data;
using pizzeriaserver.Data.Entities;
using NotFoundException = pizzeriaserver.Application.Common.Exceptions.NotFoundException;

namespace pizzeriaserver.Repositories
{
    public class ToppingRepository : IToppingRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ToppingRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            Guard.Against.Null(dbContext, nameof(dbContext));
            Guard.Against.Null(mapper, nameof(mapper));

            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ToppingDto> AddToppingAsync(ToppingDto toppingDetails)
        {
            var topping = _mapper.Map<Topping>(toppingDetails);
            var result = _dbContext.Toppings.Add(topping);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ToppingDto>(result.Entity);
        }

        public async Task<int> DeleteToppingAsync(int id)
        {
            var toppingToDelete = await _dbContext.Toppings.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (toppingToDelete == null)
            {
                throw new NotFoundException(nameof(Topping), id);
            }

            _dbContext.Toppings.Remove(toppingToDelete);
            await _dbContext.SaveChangesAsync();
            return toppingToDelete.Id;
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

        public async Task<ToppingDto> UpdateToppingAsync(ToppingDto toppingDetails)
        {
            var toppingToUpdate = await _dbContext.Toppings.Where(p => p.Id == toppingDetails.Id).FirstOrDefaultAsync();
            if (toppingToUpdate == null)
            {
                throw new NotFoundException(nameof(Topping), toppingDetails.Id);
            }

            toppingToUpdate.Name = toppingDetails.Name;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ToppingDto>(toppingToUpdate);
        }
    }
}
