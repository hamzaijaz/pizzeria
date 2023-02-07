using Microsoft.EntityFrameworkCore;
using pizzeriaserver.Models;

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

        public DbSet<Pizza> Pizzas { get; set; }
    }
}
