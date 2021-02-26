using ApiSample.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiSample.Data.Repositories.Bases
{
    public abstract class RepositoryBase<T> where T : class 
    {
        protected readonly ApiSampleContext _apiSampleContext;
        protected readonly DbSet<T> _dbSet;

        protected RepositoryBase(ApiSampleContext apiSampleContext)
        {
            this._apiSampleContext = apiSampleContext;
            this._dbSet = this._apiSampleContext.Set<T>();
        }

        protected Task SaveEntity(T entity)
        {
            _dbSet.Add(entity);
            this.Commit();

            return Task.CompletedTask;
        }

        protected Task SaveEntity<TEntityGeneric>(TEntityGeneric entity) where TEntityGeneric : class
        {
            this._apiSampleContext.Set<TEntityGeneric>().Add(entity);
            this.Commit();

            return Task.CompletedTask;
        }

        protected Task UpdateEntity(T entity)
        {
            _dbSet.Update(entity);
            Commit();

            return Task.CompletedTask;
        }

        protected Task DeleteEntity(T entity)
        {
            _dbSet.Remove(entity);
            this.Commit();

            return Task.CompletedTask;
        }

        protected void Commit()
        {
            this._apiSampleContext.SaveChanges();
        }
    }
}
