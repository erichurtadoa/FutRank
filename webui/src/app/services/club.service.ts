import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { Club } from '../models/club';
import { ClubDetails } from '../models/clubDetails';

@Injectable({
  providedIn: 'root'
})
export class ClubService {

  private baseUrl = 'https://localhost:7100/Club';
  private clubs = new BehaviorSubject<Club[]>([]);
  clubs$ = this.clubs.asObservable();

  constructor(private http: HttpClient) { }

  getClubs(): void {
    this.http.get<Club[]>(`${this.baseUrl}/All`).subscribe(clubs => {
      this.clubs.next(clubs);
    });;
  }

  getClubById(id: number): Observable<ClubDetails> {
    return this.http.get<ClubDetails>(`${this.baseUrl}/${id}`);
  }

  upVote(upVote: boolean, clubId: number): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/Vote?clubId=${clubId}`, upVote);
  }

  addFavourite(clubId: number): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/AddFavourite?clubId=${clubId}`, {});
  }

  updateClubs(clubs: Club[]): void {
    this.clubs.next(clubs);
  }
}
