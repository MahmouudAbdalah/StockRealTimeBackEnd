namespace ViewModelLayer.OrderVms
{
    public class OrderHistoryVm
    {
        public int Id { get; set; }

        public string StockSymbol { get; set; }

        public string OrderType { get; set; }

        public int Quantity { get; set; }


        public int FkOrderId { get; set; }

    }
}
