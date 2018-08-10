using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            return query.Where(predicate).ToList();
        }

        public TEntity GetByKey(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TEntity> GetByKeyAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public async void InsertAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }


        public TEntity Update(int id, TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (GetByKey(id) != null)
                {
                    throw;
                }

                return null;
            }

            return entity;
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

        public TEntity Delete(int id)
        {
            var entity = GetByKey(id);
            if (entity == null)
            {
                return null;
            }
            _dbSet.Remove(entity);
            _context.SaveChanges();
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
