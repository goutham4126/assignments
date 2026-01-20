import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-test',
  imports: [FormsModule],
  templateUrl: './test.html',
  styleUrl: './test.css',
})
export class Test {
  // Data binding

  // one way binding : 3 types
  // Interpolation
  name:string="Goutham"
  // Property binding
  imageUrl:string="https://images.pexels.com/photos/35195684/pexels-photo-35195684.jpeg"
  // Event binding
  showMessage()
  {
    console.log("the button is clicked !!")
  }

  // two way binding
  username = 'I am Goutham';
}
