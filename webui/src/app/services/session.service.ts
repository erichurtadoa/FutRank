import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { UserSession } from '../models/userSession';
import { UserRegister } from '../models/userRegister';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  private baseUrl = 'https://localhost:7100/Session';

  constructor(private http: HttpClient) { }

  login(userLogin: UserSession): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/Login`, userLogin).pipe(
      tap(response => {
        this.saveToken(response.token);
      })
    );
  }

  register(userRegister: UserRegister): Observable<any> {
    return this.http.post(`${this.baseUrl}/Register`, userRegister);
  }

  private saveToken(token: string): void {
    localStorage.setItem('jwtToken', token);
  }

  getToken(): string | null {
    return localStorage.getItem('jwtToken');
  }

  logout(): void {
    localStorage.removeItem('jwtToken');
  }
}
