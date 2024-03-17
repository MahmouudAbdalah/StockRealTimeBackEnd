using ViewModelLayer.OrderVms;

namespace BusinessLayer.IManager
{

    public interface IOrderHistoryManager
    {
        public Task<List<OrderHistoryVm>> GetAllOrders();
    }
}
