import { Component, inject, signal } from '@angular/core';
import { Auth } from '../../services/auth';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  private auth = inject(Auth);

  username = signal('');
  password = signal('');

  login() {
    this.auth.login(this.username(), this.password()).subscribe({
      next: () => {
        alert("User logged in successfully")
      },
      error: () => {
        alert('Invalid credentials');
      }
    });
  }

}
