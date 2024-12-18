import { HealthStatus } from "./health-status.model";
export class Advisor {
  id: number = -1;
  fullName: string  ="";
  sin: string = "";
  address: string = "";
  phoneNumber: string="";
  status: HealthStatus = HealthStatus.green;
}
