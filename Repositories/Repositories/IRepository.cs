
using System.Linq.Expressions;

namespace Repositories.Repositories
{

    public interface IRepository<T>
    {


        #region getter methods
        public Task<IEnumerable<T>> FetchAll();


        public Task<T> GetById(int id);

        public Task<IEnumerable<T>> GetBy(Expression<Func<T, bool>> predicate,
                                          CancellationToken cancellationToken = default);

        #endregion getter methods


        #region setter methods
        public Task Upsert(T element);

        public Task Upsert(T[] elements);

        #endregion setter methods

        #region deleter methods
        public Task Delete(T element);

        public Task Delete(T[] elements);
        #endregion deleter methods

    }
}