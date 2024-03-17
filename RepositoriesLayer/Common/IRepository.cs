using DomainLayer.Common;
using System.Linq.Expressions;

namespace RepositoriesLayer.Common
{
    public interface IRepository<T> where T : BaseDomain
    {


        IQueryable<T> GetAll();
        T GetById(int id);
        T GetBySymbol(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
    }
}
