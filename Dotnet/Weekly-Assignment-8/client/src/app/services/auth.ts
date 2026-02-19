import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class Auth {
  constructor(private http: HttpClient) {}

  login(username: string, password: string) {
    return this.http.post<any>("https://localhost:7031/api/Auth/login", {username,password});
  }

  register(userData: any) {
    return this.http.post<any>("https://localhost:7031/api/Auth/register", userData);
  }
  
}
