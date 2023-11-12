import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home/home-page/home-page.component';
import { LoginPageComponent } from './pages/account/login-page/login-page.component';
import { AppHomePageComponent } from './pages/app-home/app-home-page/app-home-page.component';
import { AuthService } from './services/account/auth.service';
import { DriverPageComponent } from './pages/driver/driver-page/driver-page.component';

const routes: Routes = [

  { path: '', component: HomePageComponent },
  { path: 'login', component: LoginPageComponent },

  {
    path: 'app',
    canActivate: [AuthService],
    children: [
      { path: '', component: AppHomePageComponent },
      {
        path: 'motoristas', component: DriverPageComponent 
      },

    ]    
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
