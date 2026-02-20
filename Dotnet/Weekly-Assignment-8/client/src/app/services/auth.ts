import { Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class Auth {
  constructor(private http: HttpClient) {}

  currentUser = signal<any>(null);

  loadUserFromToken() {
    const token = localStorage.getItem('token');
    if (!token) return;

    const decoded: any = jwtDecode(token);

    // console.log(token);
    this.currentUser.set({
      id: decoded.id,
      username: decoded.username,
      role: decoded.role
    });
    // console.log(this.currentUser);
  }

  login(username: string, password: string) {
    return this.http.post<any>("https://localhost:7031/api/Auth/login", {username,password});
  }

  register(userData: any) {
    return this.http.post<any>("https://localhost:7031/api/Auth/register", userData);
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUser.set(null);
  }
  
}
