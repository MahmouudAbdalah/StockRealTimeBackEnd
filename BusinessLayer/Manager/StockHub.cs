using Microsoft.AspNetCore.SignalR;

namespace BusinessLayer.Manager
{
    public class StockHub : Hub
    {
        public async Task UpdatePrice(decimal price)
        {


            await Clients.All.SendAsync("ReceivePriceUpdate", price);
        }
        public async Task SendMessage(decimal price)
        {

            await Clients.All.SendAsync("ReceivePriceUpdate", price);
        }
    }
}
