import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { Fixture } from '../models/fixture';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class FixtureService {

  private baseUrl = 'https://localhost:7100/Fixture';
  private fixtures = new BehaviorSubject<Fixture[]>([]);
  fixtures$ = this.fixtures.asObservable();

  constructor(private http: HttpClient) { }

  getFixtures(): void {
    this.http.get<Fixture[]>(`${this.baseUrl}/All`).subscribe(fixtures => {
      this.fixtures.next(fixtures)
    });
  }

  getUserFixtures(userId: Guid): Observable<Fixture[]> {
    return this.http.get<Fixture[]>(`${this.baseUrl}/UserFixtures/${userId}`);
  }

  voteFixture(fixtureId: number, vote: number): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/Vote?fixtureId=${fixtureId}`, vote);
  }
}
