import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { UserSession } from '../models/userSession';
import { UserRegister } from '../models/userRegister';
import { UserDetails } from '../models/userDetails';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  private baseUrl = 'https://localhost:7100/Session';
  private loggedIn = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient) { }

  get isLoggedIn(): Observable<boolean> {
    return this.loggedIn.asObservable();
  }

  login(userLogin: UserSession): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/Login`, userLogin).pipe(
      tap(response => {
        this.saveToken(response.token);
        this.loggedIn.next(true);
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

  getUser(): Observable<UserDetails> {
    return this.http.get<UserDetails>(`${this.baseUrl}/User`);
  }

  logout(): void {
    localStorage.removeItem('jwtToken');
    this.loggedIn.next(false);
  }
}
