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
import { VehicleDetailPageComponent } from './pages/vehicle/vehicle-detail-page/vehicle-detail-page.component';
import { VehicleEditPageComponent } from './pages/vehicle/vehicle-edit-page/vehicle-edit-page.component';
import { VehicleRelatorioPageComponent } from './pages/vehicle/vehicle-relatorio-page/vehicle-relatorio-page.component';
import { DriverDetailPageComponent } from './pages/driver/driver-detail-page/driver-detail-page.component';
import { RefuelingPageComponent } from './pages/refueling/refueling-page/refueling-page.component';
import { RefuelingCreatePageComponent } from './pages/refueling/refueling-create-page/refueling-create-page.component';
import { DriverEditPageComponent } from './pages/driver/driver-edit-page/driver-edit-page.component';
import { RefuelingRelatorioPageComponent } from './pages/refueling/refueling-relatorio-page/refueling-relatorio-page.component';


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
          { path: "cadastrar", component: DriverCreatePageComponent },
          { path: ":id", component: DriverDetailPageComponent },
          { path: "editar/:id", component: DriverEditPageComponent }, 
        ]        
      },
      {
        path: 'veiculos',
        children: [
          { path: '', component: VehiclePageComponent },
          { path: "cadastrar", component: VehicleCreatePageComponent },
          { path: ":id", component: VehicleDetailPageComponent },
          { path: "editar/:id", component: VehicleEditPageComponent }, 
        ]
      },

      {
        path: 'relatorios',
        children: [
          { path: "veiculos", component: VehicleRelatorioPageComponent },
          { path: "abastecimentos", component: RefuelingRelatorioPageComponent }
        ]
      },

      {
        path: 'abastecimentos',
        children: [
          { path: '', component: RefuelingPageComponent },
          { path: "cadastrar", component: RefuelingCreatePageComponent },
        //  { path: ":id", component: VehicleDetailPageComponent },
        //  { path: "editar/:id", component: VehicleEditPageComponent },
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
