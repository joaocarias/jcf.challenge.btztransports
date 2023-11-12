import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HomePageComponent } from './pages/home/home-page/home-page.component';
import { DataService } from './services/data/data.service';
import { LoginPageComponent } from './pages/account/login-page/login-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeaderDefaultComponent } from './components/shared/header-default/header-default.component';
import { AppHomePageComponent } from './pages/app-home/app-home-page/app-home-page.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { AuthService } from './services/account/auth.service';
import { DriverPageComponent } from './pages/driver/driver-page/driver-page.component';
import { DriverCreatePageComponent } from './pages/driver/driver-create-page/driver-create-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    LoginPageComponent,
    HeaderDefaultComponent,
    AppHomePageComponent,
    NavbarComponent,
    DriverPageComponent,
    DriverCreatePageComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    DataService,
    AuthService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
