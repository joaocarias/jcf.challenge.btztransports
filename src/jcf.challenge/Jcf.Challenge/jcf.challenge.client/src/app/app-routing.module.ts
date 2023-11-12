import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home/home-page/home-page.component';
import { LoginPageComponent } from './pages/account/login-page/login-page.component';
import { AppHomePageComponent } from './pages/app-home/app-home-page/app-home-page.component';
import { AuthService } from './services/account/auth.service';
import { DriverPageComponent } from './pages/driver/driver-page/driver-page.component';
import { DriverCreatePageComponent } from './pages/driver/driver-create-page/driver-create-page.component';
import { VehiclePageComponent } from './pages/vehicle/vehicle-page/vehicle-page.component';
import { VehicleCreatePageComponent } from './pages/vehicle/vehicle-create-page/vehicle-create-page.component';

const routes: Routes = [

  { path: '', component: HomePageComponent },
  { path: 'login', component: LoginPageComponent },

  {
    path: 'app',
    canActivate: [AuthService],
    children: [
      { path: '', component: AppHomePageComponent },
      {
        path: 'motoristas',
        children: [
          { path: '', component: DriverPageComponent },
          { path: "cadastrar", component: DriverCreatePageComponent }
        ]        
      },
      {
        path: 'veiculos',
        children: [
          { path: '', component: VehiclePageComponent },
          { path: "cadastrar", component: VehicleCreatePageComponent }
        ]
      },

    ]    
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
