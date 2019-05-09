import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { StatisticRoutingModule } from './statistic-routing.module';
import { StatisticComponent } from './statistic.component';

@NgModule({
  declarations: [
    StatisticComponent
  ],
  imports: [
    CommonModule,
    StatisticRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class StatisticModule { }
