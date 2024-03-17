export interface IOrderHistory {
  id: number;
  stockSymbol: string;
  orderType: string;
  quantity: number;
  fkOrderId: number;
}
