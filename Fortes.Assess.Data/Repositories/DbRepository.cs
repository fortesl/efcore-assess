using System.Reflection;
using Fortes.Assess.Data.EF;

namespace Fortes.Assess.Data.Repositories
{
    using System;
    using System.Collections;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Collections.Generic;

    public class DbRepository : IDbRepository
    {
        private readonly AssessDbContext _context;
        private dynamic _dbSet;

        public DbRepository(AssessDbContext context, string dbSet)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            SetDbSet(dbSet);
        }

        public Task<IEnumerable> GetAllAsync(params Expression<Func<object, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable> GetAllByAsync(Expression<Func<object, bool>> predicate, params Expression<Func<object, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task GetByKeyAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task ModifyAsync(object entity)
        {
            throw new NotImplementedException();
        }

        private void SetDbSet(string dbSet)
        {
  
        }
    }
}
