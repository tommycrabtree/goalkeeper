import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IGoal } from 'src/app/shared/models/goal';
import { GoalkeeperService } from '../goalkeeper.service';

@Component({
  selector: 'app-goal-profile',
  templateUrl: './goal-profile.component.html',
  styleUrls: ['./goal-profile.component.scss']
})
export class GoalProfileComponent implements OnInit {
  goal: IGoal;

  constructor(private goalkeeperService: GoalkeeperService, private activateRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadGoal();
  }

  loadGoal() {
    this.goalkeeperService.getGoal(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(
      {
        next: goal => {
          this.goal = goal;
        },
        error: err => {
          console.log(err.error);
        }
      }
    );
  }

}
