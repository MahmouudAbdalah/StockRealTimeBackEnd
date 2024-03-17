import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IOrder } from 'src/app/Models/Order/order';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }
  AddOrder(model: IOrder) {
    debugger;
    return this.http.post(`${environment.APIURL}/Order`, model);
  }
}
