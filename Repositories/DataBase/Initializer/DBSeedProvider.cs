using Data.DataBase.Initializer.appUsers.DefaultTypes;
using Data.DataBase.Initializer.appUsers.UserSeedProvider;
using Data.DbContexts.AppDbContext;
using Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Data.DataBase.Initializer
{
    public class DBSeedProvider
    {
        private IServiceScope Scope;

        private AppDbContext AppContext;

        public WebApplication App { get; }

        public DBSeedProvider(WebApplication app)
        {
            App = app;
        }

        private AppDbContext GetAppContext(IServiceScope scope)
        {
            return scope.ServiceProvider.GetRequiredService<AppDbContext>();
        }

        public IServiceScope GetScope()
        {
            var scope = this.App.Services.CreateScope();

            this.Scope = scope;

            this.AppContext = GetAppContext(scope);

            return scope;
        }

        public async Task Seed()
        {
            using (var scope = GetScope())
            {
                AddDefaultRateTypes();
            }

            using (var scope = GetScope())
            {
                await AddDefaultRoles();
            }

            using (var scope = GetScope())
            {
                await AddDefaultUsers();
            }
        }

        

        private async Task AddDefaultRoles()
        {
            var rolesManager = new AppDefaultRolesProvider(this.Scope);

            await rolesManager.CreateAsync();

            this.AppContext.SaveChanges();
        }

        private async Task AddDefaultUsers()
        {
            var userSeedProvider = new AppUserSeedProvider(this.Scope);
            await userSeedProvider.CreateAsync();
            this.AppContext.SaveChanges();
        }

        private void AddDefaultRateTypes()
        {
            
            if (!AppContext.RateEnumTypes.Any())
            {
                AppContext.RateEnumTypes.Add(new RateEnumType { Name = "Low" });
                AppContext.RateEnumTypes.Add(new RateEnumType { Name = "Medium" });
                AppContext.RateEnumTypes.Add(new RateEnumType { Name = "High" });
            }

            AppContext.SaveChanges();
        }
    }

}
