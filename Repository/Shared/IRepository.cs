using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Shared
{
     public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(params object[] keyValues);
        IQueryable<TEntity> GetQueryableAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>> predicate);
        Task<int> CountAsync();
        Task<int> CountAsyncFlitred(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> GetPageQueryableAsync(int startIndex, int pageSize, Expression<Func<TEntity, object>> predicate);
        IQueryable<TEntity> GetPageFilteredAsync(int startIndex, int pageSize
        , Expression<Func<TEntity, object>> predicate, Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TEntity>> GetPageAsync(int startIndex, int pageSize, Expression<Func<TEntity, object>> predicate);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        // This method was not in the videos, but I thought it would be useful to add.
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity); 
    }
}