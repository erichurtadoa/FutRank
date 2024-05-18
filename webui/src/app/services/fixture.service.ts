import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Fixture } from '../models/fixture';

@Injectable({
  providedIn: 'root'
})
export class FixtureService {

  private baseUrl = 'https://localhost:7100/Fixture';

  constructor(private http: HttpClient) { }

  getFixtures(): Observable<Fixture[]> {
    return this.http.get<Fixture[]>(`${this.baseUrl}/All`);
  }
}
