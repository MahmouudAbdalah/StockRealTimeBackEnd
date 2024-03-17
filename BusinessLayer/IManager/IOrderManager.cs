using ViewModelLayer.OrderVms;

namespace BusinessLayer.IManager
{

    public interface IOrderManager
    {
        Task Add(OrderVm order);
    }
}
