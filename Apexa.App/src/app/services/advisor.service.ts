
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment} from '../../environments/environment';
import { ListSearchResult } from '../models/list-search-result.model';
import { DeleteResult } from '../models/delete-result.model';
@Injectable({
  providedIn: 'root'
})
export class AdvisorService {

  constructor(private http: HttpClient) {

  }
  searchAdvisor(name: string): Observable<ListSearchResult> {
    const uriParam = `?name=${name}`;
    return this.http.get<ListSearchResult>(this.getRequestUrl(uriParam));
  }
  deleteAdvisor(id: number): Observable<DeleteResult>{
    const uriParam = `/${id}`;
    return this.http.delete<DeleteResult>(this.getRequestUrl(uriParam));
  }
  getRequestUrl(uriParams: string): string {
    return `${environment.baseUrl}`
    + `${uriParams}`;
  }
}
