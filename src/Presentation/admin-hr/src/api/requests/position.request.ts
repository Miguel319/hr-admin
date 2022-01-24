import { IPosition } from "../../models/position.model";
import http from "../http";

export class PositionRequest {
  private static readonly BASE_URL: string = "/Positions";

  static async findAll() {
    return await http.get(PositionRequest.BASE_URL);
  }

  static async findById(_id: string) {
    return await http.get(`${PositionRequest.BASE_URL}/${_id}`);
  }

  static async create(Position: IPosition) {
    return await http.post(PositionRequest.BASE_URL, Position);
  }

  static async update(_id: string, Position: IPosition) {
    return await http.put(`${PositionRequest.BASE_URL}/${_id}`, Position);
  }

  static async delete(_id: string) {
    return await http.delete(`${PositionRequest.BASE_URL}/${_id}`);
  }
}
