﻿
using Data.DbContexts.AppDbContext;
using Data.Entities;

namespace Repositories.Repositories
{
    public class RatingRepository : AbstractRepository<Rating>
    {

        private readonly AppDbContext Context;

        protected override Microsoft.EntityFrameworkCore.DbSet<Rating> Entities { get; init; }

        
        public RatingRepository(AppDbContext context): base(context)
        {
            Entities = context.Ratings;
        }

    }
}
