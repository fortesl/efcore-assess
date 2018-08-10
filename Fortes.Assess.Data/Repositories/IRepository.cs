using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fortes.Assess.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity GetByKey(int id);

        Task<TEntity> GetByKeyAsync(int id);

        TEntity Delete(int id);

        Task<TEntity> DeleteAsync(int id);
        void Insert(TEntity entity);

        void InsertAsync(TEntity entity);

        TEntity Update(int id, TEntity entity);

        Task<TEntity> UpdateAsync(int id, TEntity entity);
    }
}