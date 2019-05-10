import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './Auth/auth.guard';


const routes: Routes = [
  { path: '', loadChildren: './pages/login/login.module#LoginModule' }, 
  { path: 'login', loadChildren: './pages/login/login.module#LoginModule' },
  { path: 'choose', loadChildren: './pages/choose/choose.module#ChooseModule' },
  { path: 'game', loadChildren: './pages/game/game.module#GameModule', canActivate:[AuthGuard] },
  { path: 'statistic', loadChildren: './pages/statistic/statistic.module#StatisticModule' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
