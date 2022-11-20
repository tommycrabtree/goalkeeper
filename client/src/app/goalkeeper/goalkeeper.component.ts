import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { ICategory } from '../shared/models/category';
import { IGoal } from '../shared/models/goal';
import { GoalkeeperParams } from '../shared/models/goalkeeperParams';
import { GoalkeeperService } from './goalkeeper.service';

@Component({
  selector: 'app-goalkeeper',
  templateUrl: './goalkeeper.component.html',
  styleUrls: ['./goalkeeper.component.scss']
})
export class GoalkeeperComponent implements OnInit {
  @ViewChild('search', { static: true }) searchTerm: ElementRef;
  goals: IGoal[];
  brands: IBrand[];
  categories: ICategory[];
  goalkeeperParams = new GoalkeeperParams();
  totalCount: number;
  sortOptions = [
    {name: 'Alphabetical', value: 'name'}
  ];

  constructor(private goalkeeperService: GoalkeeperService) { }

  ngOnInit(): void {
    this.getGoals();
    this.getBrands();
    this.getCategories();
  }

  getGoals() {
    this.goalkeeperService.getGoals(this.goalkeeperParams)
      .subscribe(
        {
          next: (response) => {
            this.goals = response.data;
            this.goalkeeperParams.pageNumber = response.pageIndex;
            this.goalkeeperParams.pageSize = response.pageSize;
            this.totalCount = response.count;
          },
          error: (err) => {
            console.log(err);
          }
        });
  }

  getBrands() {
    this.goalkeeperService.getBrands()
      .subscribe(
        {
          next: (response) => {
            this.brands = [{id: 0, name: 'All'}, ...response];
          },
          error: (err) => {
            console.log(err);
          }
        });
  }

  getCategories() {
    this.goalkeeperService.getCategories()
      .subscribe(
        {
          next: (response) => {
            this.categories = [{id: 0, name: 'All'}, ...response];
          },
          error: (err) => {
            console.log(err);
          }
        });
  }

  onBrandSelected(brandId: number) {
    this.goalkeeperParams.goalBrandId = brandId;
    this.goalkeeperParams.pageNumber = 1;
    this.getGoals();
  }

  onCategorySelected(categoryId: number) {
    this.goalkeeperParams.goalCategoryId = categoryId;
    this.goalkeeperParams.pageNumber = 1;
    this.getGoals();
  }

  onSortSelected(sort: string) {
    this.goalkeeperParams.sort = sort;
    this.getGoals();
  }

  onPageChanged(event: any) {
    if (this.goalkeeperParams.pageNumber !== event) {
      this.goalkeeperParams.pageNumber = event;
      this.getGoals();
    }
  }

  onSearch() {
    this.goalkeeperParams.search = this.searchTerm.nativeElement.value;
    this.goalkeeperParams.pageNumber = 1;
    this.getGoals();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.goalkeeperParams = new GoalkeeperParams();
    this.goalkeeperParams.pageNumber = 1;
    this.getGoals();
  }
}
