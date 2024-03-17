import { Component, OnInit } from '@angular/core';
import { IStock } from 'src/app/Models/Stock/istock ';
import { StockService } from 'src/app/Services/Stock/stock.service';
import { SignalRService } from 'src/app/Services/signal-r.service';

@Component({
  selector: 'app-stock',
  templateUrl: './stock.component.html',
  styleUrls: ['./stock.component.scss']
})
export class StockComponent implements OnInit {

  stocList: IStock[] = [];
  message!: string
  constructor(private stockservice: StockService, private signalRService: SignalRService) {
  }
  ngOnInit(): void {
    this.signalRService.getMessage().subscribe(message => {
      this.message = message;
      // Handle real-time updates here
    });
    this.stockservice.getAllStocks().subscribe(data => {
      this.stocList = data;
    })
  }
  updatePrice(stock: any) {
    // Call your service method to update the price
    debugger;

    this.stockservice.updateStockPrice(stock)
      .subscribe(response => {
        this.signalRService.sendMessage(this.message)
        console.log('Price updated successfully:', this.message);
        // Update any UI or notification for successful update
      }, error => {
        console.error('Error updating price:', error);
        // Handle error, show error message or retry logic
      });
  }
}

