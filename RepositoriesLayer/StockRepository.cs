using DomainLayer.Models;
using RepositoriesLayer.Common;

namespace RepositoriesLayer
{
    public interface IStockRepsitory : IRepository<Stock>
    {

    }
    public class StockRepository : RepositoryBase<Stock>, IStockRepsitory
    {
        private StockRealTimeContext _context;


        public StockRepository(StockRealTimeContext context) : base(context)
        {
            _context = context;
        }
    }
}
