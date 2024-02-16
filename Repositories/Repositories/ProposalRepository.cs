

using Data.DbContexts.AppDbContext;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Repositories;

namespace Data.Repositories
{
    public class ProposalRepository : AbstractRepository<Proposal>
    {
        public ProposalRepository(AppDbContext context) : base(context)
        {
        }

        protected override DbSet<Proposal> Entities { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
    }
}
