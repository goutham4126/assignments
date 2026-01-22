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

  addPost(newpost:any){
    return this.http.post<any[]>('http://localhost:3000/customers',newpost)
  }

  updatePost(id:number, updatedPost:any){
    return this.http.put<any>(`http://localhost:3000/customers/${id}`, updatedPost);
  }
}
