import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IStock } from 'src/app/Models/Stock/istock ';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StockService {

  constructor(private http: HttpClient) {

  }
  getAllStocks() {
    return this.http.get<IStock[]>(`${environment.APIURL}/Stock`)
  }
  updateStockPrice(stockVm: IStock): Observable<any> {
    return this.http.post<any>(`${environment.APIURL}/stock/updatePrice`, stockVm);
  }
}
