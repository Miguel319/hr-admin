import { IDepartment } from "../../models/department.model";
import http from "../http";

export class DepartmentRequest {
  private static readonly BASE_URL: string = "/departments";

  static async findAll() {
    return await http.get(DepartmentRequest.BASE_URL);
  }

  static async findById(_id: string) {
    return await http.get(`${DepartmentRequest.BASE_URL}/${_id}`);
  }

  static async create(department: IDepartment) {
    return await http.post(DepartmentRequest.BASE_URL, department);
  }

  static async update(_id: string, department: IDepartment) {
    return await http.put(`${DepartmentRequest.BASE_URL}/${_id}`, department);
  }

  static async delete(_id: string) {
    return await http.delete(`${DepartmentRequest.BASE_URL}/${_id}`);
  }
}
