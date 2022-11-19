import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GoalProfileComponent } from './goalkeeper/goal-profile/goal-profile.component';
import { GoalkeeperComponent } from './goalkeeper/goalkeeper.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'goalkeeper', loadChildren: () => import('./goalkeeper/goalkeeper.module').then(mod => mod.GoalkeeperModule) },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
