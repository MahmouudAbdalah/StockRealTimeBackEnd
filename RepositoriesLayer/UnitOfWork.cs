using DomainLayer.Models;

namespace RepositoriesLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private StockRealTimeContext _context;
        public UnitOfWork(StockRealTimeContext context)
        {
            _context = context;
            StockRepsitory = new StockRepository(context);
            StockHistoryRepository = new StockHistoryRepository(context);
            OrderRepository = new OrderRepository(context);
            OrderHistoryRepository = new OrderHistoryRepository(context);
            UserRepsitory = new UserRepository(context);

        }
        public IStockHistoryRepository StockHistoryRepository { get; set; }

        public IOrderRepository OrderRepository { get; set; }

        public IOrderHistoryRepository OrderHistoryRepository { get; set; }

        public IStockRepsitory StockRepsitory { get; set; }
        public IUserRepsitory UserRepsitory { get; set; }

        public void Commit()
        {
            _context.SaveChanges();
        }


    }
}
