import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IGoal } from './models/goal';
import { IPagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Goalkeeper';
  goals: IGoal[];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/goals?pageSize=49')
      .subscribe(
      {
        next: (response: IPagination) => {
          this.goals = response.data;
        },
        error: (err) => {
          console.log(err);
        }
      });
  }
}
