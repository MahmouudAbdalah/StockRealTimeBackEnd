import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from './Components/MainLayout/MainLayout.component';
import { NotFoundComponent } from './Components/NotFound/NotFound.component';
import { UserLoginComponent } from './Components/UserLogin/UserLogin.component';
import { StockComponent } from './Components/stock/stock.component';
import { UserRegisterComponent } from './Components/user-register/user-register.component';
import { OrderMasterComponent } from './Components/Order/order-master.component';

const routes: Routes = [ // First-match wins strategy
  {
    path: '', component: MainLayoutComponent, children: [
      { path: '', redirectTo: '/Home', pathMatch: 'full' }, //Default path
      { path: 'Stock', component: StockComponent },
      { path: 'Order', component: OrderMasterComponent },

    ]
  },
  { path: 'Login', component: UserLoginComponent },
  { path: 'Register', component: UserRegisterComponent },
  { path: 'Logout', component: UserLoginComponent },
  { path: '**', component: NotFoundComponent }// Wild card path
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
