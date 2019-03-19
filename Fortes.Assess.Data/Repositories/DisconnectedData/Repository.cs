using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fortes.Assess.Data.Repositories.DisconnectedData 
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private readonly AssessDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(AssessDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            return await GetAllIncluding(includeProperties).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            return await query.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByKeyAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
             _dbSet.Attach(entity);
            _context.ChangeTracker.TrackGraph(entity, e => ApplyState(e.Entry));

            await _context.SaveChangesAsync();

            return entity;
        }

        private static void ApplyState(EntityEntry entry)
        {
            entry.State = entry.Property("Id").CurrentValue.Equals(0) ? EntityState.Added : EntityState.Modified;
        }

        public async Task<TEntity> UpdateAsync(int id, TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (await GetByKeyAsync(id) != null)
                {
                    throw;
                }

                return null;
            }

            return entity;
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var entity = await GetByKeyAsync(id);
            if (entity == null)
            {
                return null;
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = _dbSet;

            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
