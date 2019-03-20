using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fortes.Assess.Data.Repositories
{
    public interface IDbRepository
    {
        Task<IEnumerable> GetAllAsync(params Expression<Func<object, object>>[] includeProperties);

        Task<IEnumerable> GetAllByAsync(Expression<Func<object, bool>> predicate, params Expression<Func<object, object>>[] includeProperties);

        Task GetByKeyAsync(int id);

        Task DeleteAsync(int id);

        Task ModifyAsync(object entity);
    }
}
