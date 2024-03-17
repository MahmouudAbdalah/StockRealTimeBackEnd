using BusinessLayer.Common;
using BusinessLayer.IManager;
using Microsoft.AspNetCore.SignalR;
using RepositoriesLayer;
using ViewModelLayer.StockVms;

namespace BusinessLayer.Manager
{
    public class StockManager : ManagerBase, IStockManager
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<StockHub> _hubContext;

        public StockManager(IUnitOfWork unitOfWork, IHubContext<StockHub> hubContext) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hubContext = hubContext;
        }

        public List<StockVm> GetAllStocks()
        {
            var allstocks = _unitOfWork.StockRepsitory.GetAll()
                .Select(x => new StockVm
                {
                    Id = x.Id,
                    Code = x.Code,
                    CurrentPrice = x.CurrentPrice,
                    Symbol = x.Symbol,
                    TimeStamps = x.TimeStamps,
                }).ToList();
            return allstocks;
        }
        public async Task UpdateStockPrice(decimal price)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveStockPriceUpdate", price);
        }

    }
}
