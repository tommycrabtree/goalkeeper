import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GoalkeeperComponent } from './goalkeeper.component';
import { GoalComponent } from './goal/goal.component';
import { SharedModule } from '../shared/shared.module';
import { GoalProfileComponent } from './goal-profile/goal-profile.component';
import { GoalkeeperRoutingModule } from './goalkeeper-routing.module';



@NgModule({
  declarations: [
    GoalkeeperComponent,
    GoalComponent,
    GoalProfileComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    GoalkeeperRoutingModule
  ]
})
export class GoalkeeperModule { }
