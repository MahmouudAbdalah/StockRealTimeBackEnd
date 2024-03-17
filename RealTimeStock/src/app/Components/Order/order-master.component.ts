import { IOrder } from './../../Models/Order/order';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OrderService } from 'src/app/Services/Order/order.service';

@Component({
  selector: 'app-order-master',
  templateUrl: './order-master.component.html',
  styleUrls: ['./order-master.component.scss']
})
export class OrderMasterComponent implements OnInit {
  selectedCatID: number = 0;
  receivedOrderTotalPrice: number = 0;
  orderForm: FormGroup;
  model!: IOrder;
  constructor(private fb: FormBuilder, private orderservice: OrderService) {
    this.orderForm = this.fb.group({
      stockSymbol: ['', Validators.required],
      orderType: ['', Validators.required],
      quantity: [0, [Validators.required, Validators.min(1)]]
    });
  }

  ngOnInit(): void {

  }

  onSubmit() {
    if (this.orderForm.valid) {
      debugger;
      this.model = this.orderForm.value;
      this.orderservice.AddOrder(this.model).subscribe(() => {
        "تمت الاضافه بنجاح"
      });
    }
  }
}
