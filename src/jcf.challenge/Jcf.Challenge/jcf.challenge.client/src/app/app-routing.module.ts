import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home/home-page/home-page.component';
import { LoginPageComponent } from './pages/account/login-page/login-page.component';

const routes: Routes = [

  { path: '', component: HomePageComponent },
  { path: 'login', component: LoginPageComponent }
]


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
