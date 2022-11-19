import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { GoalkeeperComponent } from './goalkeeper.component';
import { GoalProfileComponent } from './goal-profile/goal-profile.component';

const routes: Routes = [
  { path: '', component: GoalkeeperComponent },
  { path: ':id', component: GoalProfileComponent },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class GoalkeeperRoutingModule { }
