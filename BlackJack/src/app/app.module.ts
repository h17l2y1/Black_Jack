import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountService } from '../shared/services/account.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoginComponent } from './pages/login/login.component';
import { GameComponent } from './pages/game/game.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthInterceptor } from './auth/auth.interceptor';
import { StatisticComponent } from './pages/statistic/statistic.component';
import { ChooseComponent } from './pages/choose/choose.component';


@NgModule({
   declarations: [
      AppComponent,
      LoginComponent,
      GameComponent,
      StatisticComponent,
      ChooseComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      ReactiveFormsModule,
      HttpClientModule,
      FormsModule,
      JwtModule
   ],
   providers: [AccountService, {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
   }],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
