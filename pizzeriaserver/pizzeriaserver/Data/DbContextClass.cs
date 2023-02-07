using Microsoft.EntityFrameworkCore;
using pizzeriaserver.Application.Models;

namespace pizzeriaserver.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        //}

        public DbSet<PizzaDto> Pizzas { get; set; }
        public DbSet<ToppingDto> Toppings { get; set; }
    }
}
