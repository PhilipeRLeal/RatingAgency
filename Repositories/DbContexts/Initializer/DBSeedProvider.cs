using Repositories.DbContexts.GenericDbContext;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
