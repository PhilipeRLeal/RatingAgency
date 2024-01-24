

using Microsoft.EntityFrameworkCore;
using Repositories.Entities;

namespace Repositories.DbContexts.GenericDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Insurance> Insurances { get; set; }

        public DbSet<RateTypes> RateTypes { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder
            //.Entity<RateTypes>()
            //.HasData(Enum.GetValues(typeof(RateTypesEnum))
            //    .Cast<RateTypesEnum>()
            //    .Select(e => new RateTypes(e.ToString()))
            //);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer();
        }
    }
}
