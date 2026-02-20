import { Component, inject, signal } from '@angular/core';
import { Auth } from '../../services/auth';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  private auth = inject(Auth);

  private router = inject(Router);

  username = signal('');
  password = signal('');

  login() {
    this.auth.login(this.username(), this.password()).subscribe({
      next: (res) => {
        localStorage.setItem("token",res.token);
        alert("user logged in successfully")
        if(res.role == "Admin")
        {
          this.router.navigate(["/admin/dashboard"]);
        }
        else if(res.role == "Manager")
        {
          this.router.navigate(["/manager/dashboard"]);
        }
        else
        {
          this.router.navigate(["/customer/dashboard"]);
        }
      },
      error: () => {
        alert('Invalid credentials');
      }
    });
  }

}
