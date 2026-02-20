import { Component, inject, OnInit, signal } from '@angular/core';
import { UserService } from '../../services/user';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './admin.html',
  styleUrl: './admin.css',
})
export class Admin implements OnInit {
 private userService = inject(UserService);

  users = signal<any[]>([]);
  loading = signal(true);
  error = signal('');
  

  onClick(id:any)
  {
    this.userService.deleteUser(id).subscribe(
      {
         next: (res) => {
          this.users.update(users => users.filter(u => u.id !== id));
          alert(res.message);
        },
        error: () => {
          alert("Delete failed");
        }
      }
    )
  }

  ngOnInit(): void {
    this.userService.getUsers().subscribe({
      next: (data) => {
        this.users.set(data);
        this.loading.set(false);
      },
      error: (err) => {
        this.error.set("Failed to load users");
        this.loading.set(false);
        console.error(err);
      }
    });
  }
}
