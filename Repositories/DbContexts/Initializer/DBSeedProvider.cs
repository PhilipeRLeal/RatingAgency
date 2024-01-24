using Repositories.DbContexts.GenericDbContext;
using Data.Entities;

namespace Repositories.DbContexts.Initializer
{
    public static class DBSeedProvider
    {
        public static void Seed(AppDbContext appContext)
        {
            AddRateTypes(appContext);
        }

        private static void AddRateTypes(AppDbContext appContext)
        {
            if (!appContext.RateTypes.Any())
            {
                appContext.RateTypes.Add(new RateTypes {Name = "Low" });
                appContext.RateTypes.Add(new RateTypes {Name = "Medium"});
                appContext.RateTypes.Add(new RateTypes {Name = "High"});
            }

            appContext.SaveChanges();
        }
    }
}
