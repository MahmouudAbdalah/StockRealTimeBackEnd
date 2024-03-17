using DomainLayer.Models;
using RepositoriesLayer.Common;
namespace RepositoriesLayer
{

    public interface IUserRepsitory : IRepository<User>
    {

    }
    public class UserRepository : RepositoryBase<User>, IUserRepsitory
    {
        private StockRealTimeContext _context;

        public UserRepository(StockRealTimeContext context) : base(context)
        {
            _context = context;

        }
    }

}
