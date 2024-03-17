using BusinessLayer.IManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModelLayer.OrderVms;

namespace RealTimeStock.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly IOrderHistoryManager _orderHistory;

        public OrderController(IOrderManager orderManager, IOrderHistoryManager orderHistory)
        {
            _orderManager = orderManager;
            _orderHistory = orderHistory;
        }
        [HttpPost()]
        public async Task<IActionResult> AddOrder(OrderVm orderVm)
        {
            await _orderManager.Add(orderVm);
            return Ok();
        }
        [HttpGet("orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var respons = await _orderHistory.GetAllOrders();
            return Ok(respons);
        }
    }
}
