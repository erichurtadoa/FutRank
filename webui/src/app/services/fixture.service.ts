import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { Fixture } from '../models/fixture';
import { Guid } from 'guid-typescript';
import { FixtureFilter } from '../models/fixture-filter';

@Injectable({
  providedIn: 'root'
})
export class FixtureService {

  private baseUrl = 'https://localhost:7100/Fixture';
  private fixtures = new BehaviorSubject<Fixture[]>([]);
  fixtures$ = this.fixtures.asObservable();

  constructor(private http: HttpClient) { }

  getFixtures(fixtureFilter: FixtureFilter): void {
    let params = new HttpParams();

    if (fixtureFilter.team) {
      params = params.set('team', fixtureFilter.team);
    }
    if (fixtureFilter.league) {
      params = params.set('league', fixtureFilter.league);
    }
    if (fixtureFilter.season) {
      params = params.set('season', fixtureFilter.season);
    }
    this.http.get<Fixture[]>(`${this.baseUrl}/All`, { params }).subscribe(fixtures => {
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
