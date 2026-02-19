import { Component } from '@angular/core';
import { Auth } from '../../services/auth';
import { FormsModule } from '@angular/forms';

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

  register() {
    const userData = {
      username: this.username,
      password: this.password,
      role: this.role
    };

    this.auth.register(userData).subscribe(() => {
      alert('Customer registered successfully');
    });
  }

}
