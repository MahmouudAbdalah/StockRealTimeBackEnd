export interface IStockHistory {
  id: number;
  symbol: string;
  currentPrice: number;
  timeStamps: string;
  fkStockId: number;
  stockName: string;
}
