import { IBaseModel } from "./base.model";

export interface IDepartment extends IBaseModel {
  name: string;
  code: string;
}

export interface NewDepartment {
  name: string;
  code: string;
}
