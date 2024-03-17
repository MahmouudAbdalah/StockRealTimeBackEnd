import { Component, OnInit } from '@angular/core';
import { StockService } from 'src/app/Services/Stock/stock.service';
import { UserAuthService } from 'src/app/Services/user-auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  isUserLogged: boolean;
  constructor(private authService: UserAuthService, private stockservice: StockService) {
    this.isUserLogged = this.authService.isUserLogged;

  }

  ngOnInit(): void {
    // this.isUserLogged=this.authService.isUserLogged;
    this.authService.getloggedStatus().subscribe(status => {
      this.isUserLogged = status;
    });
  }

}
