using Data.Entities;
using Repositories.Repositories;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public interface IProposalRepository: IRepository<Proposal>
    {
        Task Delete(Proposal element);
        Task Delete(Proposal[] elements);
        Task<IEnumerable<Proposal>> FetchAll();
        Task<IEnumerable<Proposal>> GetBy(Expression<Func<Proposal, bool>> predicate, CancellationToken cancellationToken = default);
        Task<Proposal> GetById(int id);
        Task Upsert(Proposal element);
        Task Upsert(Proposal[] elements);
    }
}