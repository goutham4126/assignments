import { Injectable, inject } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Auth } from '../services/auth';

@Injectable({ providedIn: 'root' })
export class RoleGuard implements CanActivate {
  private auth = inject(Auth);
  private router = inject(Router);

  canActivate(route: ActivatedRouteSnapshot): boolean {
    this.auth.loadUserFromToken();
    const user = this.auth.currentUser();
    const allowedRoles: string[] = route.data?.['roles'] || [];

    if (!user) {
      this.router.navigate(['/login']);
      return false;
    }

    if (allowedRoles.length && !allowedRoles.includes(user.role)) {
      alert('Access denied: insufficient permissions');
      this.router.navigate(['/']);
      return false;
    }

    return true;
  }
}
