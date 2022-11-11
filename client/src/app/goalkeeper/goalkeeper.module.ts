import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GoalkeeperComponent } from './goalkeeper.component';
import { GoalComponent } from './goal/goal.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    GoalkeeperComponent,
    GoalComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [GoalkeeperComponent]
})
export class GoalkeeperModule { }
