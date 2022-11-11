import { Component, Input, OnInit } from '@angular/core';
import { IGoal } from 'src/app/shared/models/goal';

@Component({
  selector: 'app-goal',
  templateUrl: './goal.component.html',
  styleUrls: ['./goal.component.scss']
})
export class GoalComponent implements OnInit {
  @Input() goal: IGoal;

  constructor() { }

  ngOnInit(): void {
  }

}
