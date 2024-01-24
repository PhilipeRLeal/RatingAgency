using Repositories.DbContexts.GenericDbContext;
using Repositories.Entities;

namespace Repositories.Repositories
{


    public class InsuranceRepository : AbstractRepository<Insurance>
    {

        protected override Microsoft.EntityFrameworkCore.DbSet<Insurance> Entities { get; init; }

        public InsuranceRepository(AppDbContext context) : base(context)
        {
            Entities = context.Insurances;
        }

    }
}
