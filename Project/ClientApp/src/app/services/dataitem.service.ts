import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DataItemService {

  constructor(private http: HttpClient) { }

  fetchDataItems(): Observable<Object> {
    return this.http.get('/api/dataitems');
  }

}
