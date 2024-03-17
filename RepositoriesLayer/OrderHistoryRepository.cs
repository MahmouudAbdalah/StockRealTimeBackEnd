using DomainLayer.Models;
using RepositoriesLayer.Common;

namespace RepositoriesLayer
{

    public interface IOrderHistoryRepository : IRepository<OrdersHistory>
    {

    }
    public class OrderHistoryRepository : RepositoryBase<OrdersHistory>, IOrderHistoryRepository
    {
        private StockRealTimeContext _context;


        public OrderHistoryRepository(StockRealTimeContext context) : base(context)
        {
            _context = context;
        }
    }
}
