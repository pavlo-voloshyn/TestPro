import { Observable } from 'rxjs';
import { Test } from './../models/Test';
import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  constructor(private http: HttpClient) { }

  getTests(id: string): Observable<Test[]> {
    return this.http.get<Test[]>(environment.apiUrl + '/Test/tests?user_id=' +  id)
  }

  getResult(id: string, answers: string[]): Observable<boolean[]>  {
    return this.http.post<boolean[]>(environment.apiUrl + '/Test/check_tests', {id : id, answers : answers})
  }
}
