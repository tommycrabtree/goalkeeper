import { IGoal } from './goal';

export interface IPagination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IGoal[];
}
