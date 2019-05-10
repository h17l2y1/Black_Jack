import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChooseRoutingModule } from './choose-routing.module';
import { ChooseComponent } from './choose.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ChooseComponent
  ],
  imports: [
    CommonModule,
    ChooseRoutingModule,
    ReactiveFormsModule,
    FormsModule,
  ]
})
export class ChooseModule { }
