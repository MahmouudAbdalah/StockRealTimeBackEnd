using DomainLayer.Common;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RepositoriesLayer.Common
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : BaseDomain
    {




        private StockRealTimeContext _context;
        protected RepositoryBase(StockRealTimeContext context)
        {
            _context = context;
        }
        public virtual async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual TEntity GetBySymbol(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }
        public TEntity Find(Expression<Func<TEntity, bool>> criteria, string[] includes = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return query.SingleOrDefault(criteria);
        }
    }
}
