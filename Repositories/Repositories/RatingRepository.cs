

using Microsoft.EntityFrameworkCore;
using Repositories.DbContexts.GenericDbContext;
using Repositories.Entities;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Repositories.Repositories
{
    public class RatingRepository : AbstractRepository<Rating>
    {

        private readonly AppDbContext Context;

        protected override Microsoft.EntityFrameworkCore.DbSet<Rating> Entities { get; init; }

        
        public RatingRepository(AppDbContext context): base(context)
        {
            Entities = Context.Ratings;
        }

    }
}
