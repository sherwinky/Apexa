import { Advisor } from './advisor.model';
import { ValidationResult } from './validation-result.model';
export class DeleteResult {
  success:boolean = true;
  errors:ValidationResult[] = [];
  result:any;
}
