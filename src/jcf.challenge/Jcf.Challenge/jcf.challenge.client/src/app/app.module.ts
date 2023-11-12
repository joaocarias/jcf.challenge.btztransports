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
import { MaskDirective } from './directives/mask.dirctive';
import { VehiclePageComponent } from './pages/vehicle/vehicle-page/vehicle-page.component';
import { VehicleCreatePageComponent } from './pages/vehicle/vehicle-create-page/vehicle-create-page.component';
import { VehicleDetailPageComponent } from './pages/vehicle/vehicle-detail-page/vehicle-detail-page.component';
import { VehicleEditPageComponent } from './pages/vehicle/vehicle-edit-page/vehicle-edit-page.component';
import { VehicleRelatorioPageComponent } from './pages/vehicle/vehicle-relatorio-page/vehicle-relatorio-page.component';
import { DriverDetailPageComponent } from './pages/driver/driver-detail-page/driver-detail-page.component';
import { RefuelingPageComponent } from './pages/refueling/refueling-page/refueling-page.component';
import { RefuelingCreatePageComponent } from './pages/refueling/refueling-create-page/refueling-create-page.component';
import { DriverEditPageComponent } from './pages/driver/driver-edit-page/driver-edit-page.component';
import { RefuelingRelatorioPageComponent } from './pages/refueling/refueling-relatorio-page/refueling-relatorio-page.component';


@NgModule({
  declarations: [
    MaskDirective,
    AppComponent,    
    HomePageComponent,
    LoginPageComponent,
    HeaderDefaultComponent,
    AppHomePageComponent,
    NavbarComponent,
    DriverPageComponent,
    DriverCreatePageComponent,
    DriverEditPageComponent,
    VehiclePageComponent,
    VehicleCreatePageComponent,
    VehicleDetailPageComponent,
    VehicleEditPageComponent,
    VehicleRelatorioPageComponent,
    DriverDetailPageComponent,
    RefuelingPageComponent,
    RefuelingCreatePageComponent,
    RefuelingRelatorioPageComponent,
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
