import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Components/header/header.component';
import { FooterComponent } from './Components/footer/footer.component';
import { SidebarComponent } from './Components/sidebar/sidebar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrderMasterComponent } from './Components/Order/order-master.component';
import { UserLoginComponent } from './Components/UserLogin/UserLogin.component';
import { NotFoundComponent } from './Components/NotFound/NotFound.component';
import { MainLayoutComponent } from './Components/MainLayout/MainLayout.component';
import { UserRegisterComponent } from './Components/user-register/user-register.component';
import { StockComponent } from './Components/stock/stock.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
    OrderMasterComponent,
    UserLoginComponent,
    NotFoundComponent,
    MainLayoutComponent,
    UserRegisterComponent,
    StockComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
