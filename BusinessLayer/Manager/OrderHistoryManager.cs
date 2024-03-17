using BusinessLayer.Common;
using BusinessLayer.IManager;
using Microsoft.EntityFrameworkCore;
using RepositoriesLayer;
using ViewModelLayer.OrderVms;

namespace BusinessLayer.Manager
{
    public class OrderHistoryManager : ManagerBase, IOrderHistoryManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderHistoryManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {


            _unitOfWork = unitOfWork;
        }


        public async Task<List<OrderHistoryVm>> GetAllOrders()
        {

            var allstocks = await _unitOfWork.OrderHistoryRepository.GetAll()
                .Select(x => new OrderHistoryVm
                {
                    Id = x.Id,
                    FkOrderId = x.FkOrderId,
                    OrderType = x.OrderType,
                    Quantity = x.Quantity,
                    StockSymbol = x.StockSymbol
                }).ToListAsync();
            return allstocks;
        }
    }
}
