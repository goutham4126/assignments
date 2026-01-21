import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
    // constructor injection to use a http client service that contains all the things like.
    constructor(private http:HttpClient){}
    getTodos()
    {
      return this.http.get<any[]>('http://localhost:3000/customers')
    }

    getTodoById(id:string)
    {
      return this.http.get<any[]>(`http://localhost:3000/customers/${id}`)
    }
}
