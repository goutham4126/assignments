import { Component, signal, inject } from '@angular/core';
import { Header } from './components/header/header';
import { RouterOutlet } from '@angular/router';
import { Auth } from './services/auth';

@Component({
  selector: 'app-root',
  imports: [Header,RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App{
  protected readonly title = signal('frontend');
  constructor(){
    const auth = inject(Auth);
    auth.loadUserFromToken();
  }
  
}
