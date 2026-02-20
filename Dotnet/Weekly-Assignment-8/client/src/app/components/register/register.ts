import { Component, inject } from '@angular/core';
import { Auth } from '../../services/auth';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {

  username = '';
  password = '';
  role = '';

  constructor(private auth: Auth) {}
  private router = inject(Router);

  register() {
    const userData = {
      username: this.username,
      password: this.password,
      role: this.role
    };

    this.auth.register(userData).subscribe(() => {
      alert('user registered successfully');
      this.router.navigate(["/login"]);
    });
  }

}
