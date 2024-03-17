import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IStockHistory } from 'src/app/Models/Stock/istock-history';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StockHistoryService {

  constructor(private http: HttpClient) { }
  getStockHistory(symbol: string): Observable<IStockHistory> {
    return this.http.get<IStockHistory>(`${environment.APIURL}/${symbol}/history`)
  }
}
