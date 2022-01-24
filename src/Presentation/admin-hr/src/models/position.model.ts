import { IBaseModel } from "./base.model";

export interface IPosition extends IBaseModel {
  name: string;
  minSalary: number;
  maxSalary: number;
}

export interface INewPosition {
  name: string;
  minSalary: number;
  maxSalary: number;
}
