import { Component, OnInit, signal, inject } from '@angular/core';
import { TodoService } from '../../app/services/todo-service';
// import { ChangeDetectorRef } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-todo-component',
    imports:[FormsModule],
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


    // ---------- ADD FORM STATE ----------
    newPost = signal({
        name: '',
        email: '',
        city: ''
    });

    // ---------- EDIT FORM STATE ----------
    editPost = signal<any>(null);

    // ---------- ADD POST ----------
    DeletePost(id: number) {
        this.todoService.deletePosts(id).subscribe(() => {
            this.posts.set(this.posts().filter(post => post.id !== id));
        });
    }

    // ---------- ADD POST ----------
    addPost() {
        this.todoService.addPost(this.newPost()).subscribe((createdPost) => {
            this.posts.set([...this.posts(), createdPost]);
            this.newPost.set({ name:'', email:'', city:'' });
        });
    }

    // ---------- SET EDIT MODE ----------
    setEdit(post:any) {
        this.editPost.set({...post});
    }

    // ---------- UPDATE POST ----------
    updatePost() {
        const post = this.editPost();
        this.todoService.updatePost(post.id, post).subscribe(() => {
            this.posts.set(
                this.posts().map(p => p.id === post.id ? post : p)
            );
            this.editPost.set(null);
        });
    }
}
