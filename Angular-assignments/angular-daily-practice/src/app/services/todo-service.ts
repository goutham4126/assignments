
import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  private http = inject(HttpClient);

  getPosts(){
    return this.http.get<any[]>('http://localhost:3000/customers');
  }

  deletePosts(id:number){
    return this.http.delete<any[]>(`http://localhost:3000/customers/${id}`);
  }
}