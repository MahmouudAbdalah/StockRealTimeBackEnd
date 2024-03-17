namespace ViewModelLayer.StockVms
{
    public class StockVm
    {
        public int Id { get; set; }

        public string Symbol { get; set; }

        public string Code { get; set; }

        public decimal CurrentPrice { get; set; }

        public DateTime TimeStamps { get; set; }

    }
}
