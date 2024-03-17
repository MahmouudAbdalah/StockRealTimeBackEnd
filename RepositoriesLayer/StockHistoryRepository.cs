using DomainLayer.Models;
using RepositoriesLayer.Common;

namespace RepositoriesLayer
{

    public interface IStockHistoryRepository : IRepository<StockHistory>
    {

    }
    public class StockHistoryRepository : RepositoryBase<StockHistory>, IStockHistoryRepository
    {
        private StockRealTimeContext _context;


        public StockHistoryRepository(StockRealTimeContext context) : base(context)
        {
            _context = context;
        }
    }
}
