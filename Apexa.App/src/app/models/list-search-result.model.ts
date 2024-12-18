import { Advisor } from './advisor.model';
import { ValidationResult } from './validation-result.model';
export class ListSearchResult {
  success:boolean = true;
  errors:ValidationResult[] = [];
  result:Advisor[] = [];
}
