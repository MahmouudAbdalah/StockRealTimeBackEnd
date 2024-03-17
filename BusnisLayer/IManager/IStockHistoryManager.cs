using ViewModelLayer.StockVms;

namespace BusinessLayer.IManager
{

    public interface IStockHistoryManager
    {
        public StockHistoryVm GetStockHistoryBySymbol(string symbol);
    }
}
