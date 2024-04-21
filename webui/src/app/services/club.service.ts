import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Club } from '../models/club';

@Injectable({
  providedIn: 'root'
})
export class ClubService {

  private baseUrl = 'https://localhost:7100/Club';

  constructor(private http: HttpClient) { }

  getClubs(): Observable<Club[]> {
    return this.http.get<Club[]>(`${this.baseUrl}/Clubs`);
  }
}
