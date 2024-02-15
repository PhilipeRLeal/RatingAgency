
using Data.DbContexts.AppDbContext;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Repositories.Repositories
{
    public abstract class AbstractRepository<T>: IRepository<T> where T : BaseEntity
    {

        private readonly AppDbContext Context;

        protected abstract DbSet<T> Entities { get; init; }


        public AbstractRepository(AppDbContext context)
        {
            Context = context;
        }

        #region deletion
        public virtual async Task Delete(T element)
        {
            await Entities.Where(element => element.Id == element.Id).ExecuteDeleteAsync();
            await Context.SaveChangesAsync();

        }

        public virtual async Task Delete(T[] elements)
        {
            foreach (var element in elements)
            {
                await this.Delete(element);
            }
        }

        #endregion deletion

        #region data fetch

        public virtual async Task<IEnumerable<T>> FetchAll()
        {
            return await Entities.ToListAsync();

        }

        public virtual async Task<IEnumerable<T>> GetBy(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {

            var instances = await Entities.Where(predicate).ToListAsync();

            return instances;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await Entities.FirstAsync(x => x.Id == id);
        }

        #endregion data fetch

        #region Upsert

        public virtual async Task Upsert(T element)
        {
            await Entities.AddAsync(element);
            try { 
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public virtual async Task Upsert(T[] elements)
        {
            foreach (var element in elements)
            {
                await this.Upsert(element);
            }
        }

        #endregion Upsert
    }
}
