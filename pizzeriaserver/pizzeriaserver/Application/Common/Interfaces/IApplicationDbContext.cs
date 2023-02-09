using Microsoft.EntityFrameworkCore;
using pizzeriaserver.Data.Entities;

namespace pizzeriaserver.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Pizza> Pizzas { get; set; }
        DbSet<Topping> Toppings { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
