using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Shared
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected DbSet<TEntity> Entities;
        public Repository(DbContext context)
        {
            Context = context;
            Entities = Context.Set<TEntity>();  
        }

        public async Task<TEntity> GetAsync(params object[] keyValues)
        {
            return await Entities.FindAsync(keyValues);
        }

        public IQueryable<TEntity> GetQueryableAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>> predicate)
        {
            return await Entities.OrderByDescending(predicate).ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await Entities.CountAsync();
        }

        public async Task<int> CountAsyncFlitred(Expression<Func<TEntity, bool>> filter)
        {
            return await Entities.Where(filter).CountAsync();
        }

        public IQueryable<TEntity> GetPageQueryableAsync(int startIndex, int pageSize, Expression<Func<TEntity, object>> predicate)
        {
            return Entities.OrderByDescending(predicate)
                    .Skip(startIndex)
                    .Take(pageSize);
        }

        public async Task<IEnumerable<TEntity>> GetPageAsync(int startIndex, int pageSize, Expression<Func<TEntity, object>> predicate)
        {
            return await Entities.OrderByDescending(predicate)
                    .Skip(startIndex)
                    .Take(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities.SingleOrDefaultAsync(predicate);
        }

        public async Task AddAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await Entities.AddRangeAsync(entities);
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Entities.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            // entity.Attach(entityToUpdate);  
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<TEntity> GetPageFilteredAsync(
            int startIndex, 
            int pageSize, 
            Expression<Func<TEntity, object>> predicate,
            Expression<Func<TEntity, bool>> filter
            )
        {
            return Entities
                    .OrderByDescending(predicate)
                    .Where(filter)
                    .Skip(startIndex)
                    .Take(pageSize);
        }
    }

}