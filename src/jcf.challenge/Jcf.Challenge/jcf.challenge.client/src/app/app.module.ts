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

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    LoginPageComponent,
    HeaderDefaultComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    DataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
