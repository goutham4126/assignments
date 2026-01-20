import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Employees } from '../components/employees/employees';
import { Test } from '../components/test/test';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,Employees,Test],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Day-16');
  
  isLoggedIn:boolean=true
}
