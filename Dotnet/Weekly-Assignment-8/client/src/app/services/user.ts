import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UserService {

  private http = inject(HttpClient);

  getUsers() {
    return this.http.get<any[]>("https://localhost:7055/api/Admin");
  }

  deleteUser(id:any)
  {
    return this.http.delete<any>(`https://localhost:7055/api/Admin/${id}`)
  }

  
}
