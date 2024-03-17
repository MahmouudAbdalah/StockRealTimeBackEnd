using ViewModelLayer.StockVms;

namespace BusinessLayer.IManager
{

    public interface IStockManager
    {

        public List<StockVm> GetAllStocks();
        public Task UpdateStockPrice(decimal price);

    }
}
