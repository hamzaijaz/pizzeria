using Microsoft.EntityFrameworkCore;
using pizzeriaserver.Application.Common.Exceptions;
using pizzeriaserver.Application.Common.Interfaces;
using pizzeriaserver.Data.Entities;
using System.Text.RegularExpressions;

namespace pizzeriaserver.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        //}

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // before we save changes, automatically set the ModifiedOnUtc column
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                entry.Metadata.FindDeclaredProperty("ModifiedOnUtc")?.PropertyInfo.SetValue(entry.Entity, _dateTime.UtcNow);
            }

            try
            {
                return await base.SaveChangesAsync(cancellationToken);
            }

            catch (Exception ex)
            {
                // Detect duplicate key errors.
                if (ex.InnerException != null && ex.InnerException.Message.Contains("Cannot insert duplicate key"))
                {
                    var r = new Regex(@"(dbo.)(\*|\w+)",
                        RegexOptions.IgnoreCase | RegexOptions.Compiled);

                    Match m = r.Match(ex.InnerException.Message);
                    if (m.Success && m.Groups.Count > 1)
                    {
                        throw new DuplicateItemException(m.Groups[2].Value);
                    }
                    else
                    {
                        throw new DuplicateItemException(ChangeTracker.Entries().First().Entity.GetType().Name);
                    }
                }
                throw;
            }
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PizzaLocation> PizzaLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaLocation>()
                .HasKey(pl => new { pl.PizzaId, pl.LocationId });

            modelBuilder.Entity<Location>()
            .HasIndex(p => p.Name)
            .IsUnique();
        }
    }
}
