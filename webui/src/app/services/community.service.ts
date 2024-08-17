import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ForumThread } from '../models/forum-thread';
import { Comments } from '../models/comment';

@Injectable({
  providedIn: 'root'
})
export class ForumService {
  private apiUrl = 'https://localhost:7100/Forum';

  constructor(private http: HttpClient) { }

  getThreads(): Observable<ForumThread[]> {
    return this.http.get<ForumThread[]>(`${this.apiUrl}/threads`);
  }

  getThread(id: number): Observable<ForumThread> {
    return this.http.get<ForumThread>(`${this.apiUrl}/threads/${id}`);
  }

  createThread(title: string): Observable<ForumThread> {
    var body = JSON.stringify(title);
    console.log(body);
    return this.http.post<ForumThread>(`${this.apiUrl}/threads`, body, {
      headers: { 'Content-Type': 'application/json' }
    });
  }

  createcomments(threadId: number, content: string): Observable<Comments> {
    var body = JSON.stringify(content);
    return this.http.post<Comments>(`${this.apiUrl}/threads/${threadId}/comments`, body, {
      headers: { 'Content-Type': 'application/json' }
    });
  }
}
