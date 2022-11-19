import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { IBrand } from '../shared/models/brand';
import { ICategory } from '../shared/models/category';
import { IGoal } from '../shared/models/goal';
import { GoalkeeperParams } from '../shared/models/goalkeeperParams';
import { IPagination } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root'
})
export class GoalkeeperService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getGoals(goalkeeperParams: GoalkeeperParams) {
    let params = new HttpParams();

    if (goalkeeperParams.goalBrandId !== 0) {
      params = params.append('goalBrandId', goalkeeperParams.goalBrandId.toString());
    }

    if (goalkeeperParams.goalCategoryId !== 0) {
      params = params.append('goalCategoryId', goalkeeperParams.goalCategoryId.toString());
    }

    if (goalkeeperParams.search) {
      params = params.append('search', goalkeeperParams.search);
    }

    params = params.append('sort', goalkeeperParams.sort);
    params = params.append('pageIndex', goalkeeperParams.pageNumber.toString());
    params = params.append('pageSize', goalkeeperParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'goals',
      { observe: 'response', params })
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }

  getGoal(id: number) {
    return this.http.get<IGoal>(this.baseUrl + 'goals/' + id);
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'goals/brands');
  }

  getCategories() {
    return this.http.get<ICategory[]>(this.baseUrl + 'goals/categories');
  }
}
