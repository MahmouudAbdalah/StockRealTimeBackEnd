using BusinessLayer.Common;
using BusinessLayer.IManager;
using DomainLayer.Models;
using RepositoriesLayer;
using ViewModelLayer.OrderVms;

namespace BusinessLayer.Manager
{
    public class OrderManager : ManagerBase, IOrderManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {


            _unitOfWork = unitOfWork;
        }
        public async Task Add(OrderVm model)
        {
            Order order = new Order
            {
                OrderType = model.OrderType.Trim(),
                Quantity = model.Quantity,
                StockSymbol = model.StockSymbol,
            };
            await _unitOfWork.OrderRepository.AddAsync(order);
            _unitOfWork.Commit();
        }
    }
}
