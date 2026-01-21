import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { TodoService } from '../../app/services/todo-service';

@Component({
  selector: 'app-todo-component',
  templateUrl: './todo-component.html',
  styleUrl: './todo-component.css',
})
export class TodoComponent implements OnInit {

  todos: any[] = [];

  constructor(private todoService: TodoService,private cdr: ChangeDetectorRef) {}

  ngOnInit() {
    this.loadTodos();
  }

  loadTodos() {
    this.todoService.getTodos().subscribe(res => {
      this.todos = res;
      this.cdr.detectChanges();
    });
  }
}
