import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
// import { SignUpComponent } from './pages/sign-up/sign-up.component';
import { GameComponent } from './pages/game/game.component';
import { AuthGuard } from './Auth/auth.guard';
import { StatisticComponent } from './pages/statistic/statistic.component';

const routes: Routes = [
  { path:'', redirectTo:'/login', pathMatch: 'full' }, 
  //{ path: 'sign-up', component: SignUpComponent },
  { path: 'login', component: LoginComponent },
  { path: 'game', component: GameComponent, canActivate:[AuthGuard] },
  { path: 'statistic', component: StatisticComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
