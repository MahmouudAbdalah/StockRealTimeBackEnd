namespace RepositoriesLayer
{
    public interface IUnitOfWork
    {
        IStockHistoryRepository StockHistoryRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderHistoryRepository OrderHistoryRepository { get; }
        IStockRepsitory StockRepsitory { get; }
        IUserRepsitory UserRepsitory { get; }

        void Commit();

    }
}
