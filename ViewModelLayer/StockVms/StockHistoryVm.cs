namespace ViewModelLayer.StockVms
{
    public class StockHistoryVm
    {
        public int Id { get; set; }

        public string Symbol { get; set; }

        public decimal CurrentPrice { get; set; }

        public DateTime TimeStamps { get; set; }


        public int FkStockId { get; set; }
        public string StockName { get; set; }
    }
}
