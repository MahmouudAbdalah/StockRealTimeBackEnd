using BusinessLayer.IManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModelLayer.StockVms;

namespace RealTimeStock.Controllers.Stock
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StockController : ControllerBase
    {
        private readonly IStockManager _stockManager;
        private readonly IStockHistoryManager _stockHistory;

        public StockController(IStockManager stockManager, IStockHistoryManager stockHistory)
        {
            _stockManager = stockManager;
            _stockHistory = stockHistory;

        }
        [HttpGet]
        public IActionResult GetAllStock()
        {
            var response = _stockManager.GetAllStocks();
            return Ok(response);
        }
        [HttpGet("{symbol}/history")]
        public IActionResult GetStockHistoryBySymbol(string symbol)
        {
            var response = _stockHistory.GetStockHistoryBySymbol(symbol);
            return Ok(response);
        }
        [HttpPost("updatePrice")]
        public async Task<IActionResult> UpdatePrice(StockVm stockVm)
        {

            await _stockManager.UpdateStockPrice(stockVm.CurrentPrice);
            return Ok();
        }
    }
}
