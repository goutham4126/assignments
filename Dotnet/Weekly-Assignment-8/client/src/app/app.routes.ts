import { Routes } from '@angular/router';
import { Login } from './components/login/login';
import { Register } from './components/register/register';
import { Home } from './components/home/home';
import { Admin } from './components/admin/admin';
import { Manager } from './components/manager/manager';
import { Customer } from './components/customer/customer';
import { RoleGuard } from './guards/role-guard';

export const routes: Routes = [
    {
        path: "login",
        component : Login
    },
    {
        path: "register",
        component : Register
    },
    {
        path: "",
        component: Home
    },
    {
        path : "admin/dashboard",
        component: Admin,
        canActivate: [RoleGuard],
        data: { roles: ['Admin'] }
    },
    {
        path: "manager/dashboard",
        component: Manager,
        canActivate: [RoleGuard],
        data: { roles: ['Manager'] }
    },
    {
        path: "customer/dashboard",
        component: Customer,
        canActivate: [RoleGuard],
        data: { roles: ['Customer'] }
    },
    { 
        path: '**', 
        redirectTo: '' 
    }
];
