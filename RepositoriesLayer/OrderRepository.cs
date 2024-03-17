using DomainLayer.Models;
using RepositoriesLayer.Common;

namespace RepositoriesLayer
{

    public interface IOrderRepository : IRepository<Order>
    {

    }
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private StockRealTimeContext _context;


        public OrderRepository(StockRealTimeContext context) : base(context)
        {
            _context = context;
        }
    }
}
