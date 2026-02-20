import { Component, inject, OnInit } from '@angular/core';
import { Auth } from '../../services/auth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.html',
  styleUrl: './header.css',
})
export class Header implements OnInit {
  private authService = inject(Auth);
  private router = inject(Router);
  user = this.authService.currentUser;
  Logout()
  {
    this.authService.logout();
    this.router.navigate(["/"]);
  }
  ngOnInit(): void {
    this.authService.loadUserFromToken();
  }
}
