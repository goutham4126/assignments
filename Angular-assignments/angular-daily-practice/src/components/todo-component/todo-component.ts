import { Component, OnInit, signal, inject } from '@angular/core';
import { TodoService } from '../../app/services/todo-service';
import { ChangeDetectorRef } from '@angular/core';

@Component({
    selector: 'app-todo-component',
    templateUrl: './todo-component.html',
    styleUrls: ['./todo-component.css']
})
export class TodoComponent implements OnInit {
    posts = signal<any[]>([]);
    // posts:any[]=[]

    private todoService = inject(TodoService);

    // constructor(private todoService:TodoService,private cdr:ChangeDetectorRef){}

    ngOnInit() {
        this.todoService.getPosts().subscribe(data =>this.posts.set(data));
        // this.todoService.getPosts().subscribe((data)=>
        //     {
        //         this.posts=data;
        //         this.cdr.detectChanges();
        //     }
        // )
    }

    DeletePost(id: number) {
        this.todoService.deletePosts(id).subscribe(() => {
            this.posts.set(this.posts().filter(post => post.id !== id));
        });
    }


}