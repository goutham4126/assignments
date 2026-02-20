import { Component, inject, signal } from '@angular/core';
import { Auth } from '../../services/auth';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [FormsModule,CommonModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  private auth = inject(Auth);
  private router = inject(Router);

  username = signal('');
  password = signal('');

  // Captcha signals
  generatedCaptcha = signal('');
  enteredCaptcha = signal('');
  captchaError = signal('');

  constructor() {
    this.generateCaptcha();
  }

  generateCaptcha() {
    const chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    let captcha = '';

    for (let i = 0; i < 6; i++) {
      captcha += chars.charAt(Math.floor(Math.random() * chars.length));
    }

    this.generatedCaptcha.set(captcha);
  }

  login() {

  // Keep your existing empty validation (if any)
    if (!this.username().trim() || !this.password().trim()) {
      alert("Username and Password required");
      return;
    }

    // NEW: Validate captcha BEFORE sending request
    if (this.enteredCaptcha().trim() !== this.generatedCaptcha()) {
      this.captchaError.set("Invalid CAPTCHA");
      alert("Invalid Captcha !!")
      this.generateCaptcha();   // optional: regenerate
      this.enteredCaptcha.set('');
      return; // STOP here, do NOT call API
    }

    // Clear error if correct
    this.captchaError.set('');

    // Your previous functionality remains EXACTLY same
    this.auth.login(this.username(), this.password()).subscribe({
      next: (res) => {
        localStorage.setItem("token", res.token);
        alert("User logged in successfully");

        if (res.role == "Admin") {
          this.router.navigate(["/admin/dashboard"]);
        } else if (res.role == "Manager") {
          this.router.navigate(["/manager/dashboard"]);
        } else {
          this.router.navigate(["/customer/dashboard"]);
        }
      },
      error: () => {
        alert('Invalid credentials');
      }
    });
  }
}