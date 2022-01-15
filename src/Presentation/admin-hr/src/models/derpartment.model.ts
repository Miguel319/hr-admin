export interface IDepartment {
  id: string;
  name: string;
  code: string;
  createdAt: Date | string;
  updatedAt: Date | string;
}

export interface NewDepartment {
  name: string;
  code: string;
}
