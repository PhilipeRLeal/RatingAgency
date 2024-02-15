using Data.DataBase.Identity;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
namespace Data.DbContexts.AppDbContext;

public class AppDbContext : IdentityDbContext<CustomIdentityUser, 
                                              CustomIdentityRole, 
                                              int, 
                                              CustomIdentityClaim, 
                                              CustomIdentityUserRole,
                                              CustomIdentityLogin, 
                                              IdentityRoleClaim<int>, 
                                              IdentityUserToken<int>
                                              >
{
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        


        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer();
    }

    

    public DbSet<Insurance> Insurances { get; set; }

    public DbSet<RateEnumType> RateEnumTypes { get; set; }

    public DbSet<Rating> Ratings { get; set; }
}
