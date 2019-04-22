import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatisticRoutingModule } from './statistic-routing.module';
import { StatisticComponent } from './statistic.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    StatisticComponent
  ],
  imports: [
    CommonModule,
    StatisticRoutingModule,
    ReactiveFormsModule,
    FormsModule,
  ]
})
export class StatisticModule { }
