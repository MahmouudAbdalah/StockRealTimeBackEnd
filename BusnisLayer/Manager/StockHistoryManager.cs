using BusinessLayer.Common;
using BusinessLayer.IManager;
using RepositoriesLayer;
using ViewModelLayer.StockVms;

namespace BusinessLayer.Manager
{
    public class StockHistoryManager : ManagerBase, IStockHistoryManager
    {

        private readonly IUnitOfWork _unitOfWork;

        public StockHistoryManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public StockHistoryVm GetStockHistoryBySymbol(string symbol)
        {
            var stockHistoryVm = (from sh in _unitOfWork.StockHistoryRepository.GetAll()
                                  join st in _unitOfWork.StockRepsitory.GetAll() on sh.FkStockId equals st.Id
                                  where sh.Symbol.ToLower().Trim() == symbol.ToLower().Trim()
                                  select new StockHistoryVm()
                                  {
                                      CurrentPrice = sh.CurrentPrice,
                                      StockName = st.Symbol,
                                      Id = sh.Id,
                                      Symbol = sh.Symbol,
                                      TimeStamps = sh.TimeStamps,
                                      FkStockId = sh.FkStockId,
                                  }).FirstOrDefault();

            return stockHistoryVm ?? throw new Exception("Not Found");
        }
    }
}
