import { Component, OnInit, signal, inject } from '@angular/core';
import { TodoService } from '../../app/services/todo-service';

@Component({
    selector: 'app-todo-component',
    templateUrl: './todo-component.html',
    styleUrls: ['./todo-component.css']
})
export class TodoComponent implements OnInit {
    posts = signal<any[]>([]);

    private todoService = inject(TodoService);

    ngOnInit() {
        this.todoService.getPosts().subscribe(data =>this.posts.set(data));
    }
}