import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Club } from '../models/club';
import { ClubDetails } from '../models/clubDetails';

@Injectable({
  providedIn: 'root'
})
export class ClubService {

  private baseUrl = 'https://localhost:7100/Club';

  constructor(private http: HttpClient) { }

  getClubs(): Observable<Club[]> {
    return this.http.get<Club[]>(`${this.baseUrl}/All`);
  }

  getClubById(id: number): Observable<ClubDetails> {
    return this.http.get<ClubDetails>(`${this.baseUrl}/${id}`);
  }

  upVote(upVote: boolean): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/Vote`, upVote);
  }
}
