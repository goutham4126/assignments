import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {ReactiveFormsModule,Validators, FormControl, FormGroup } from '@angular/forms';
@Component({
  selector: 'app-formdemo',
  imports: [FormsModule],
  // imports:[ReactiveFormsModule],
  templateUrl: './formdemo.html',
  styleUrl: './formdemo.css',
})
export class Formdemo {
  // submitForm(form:any)
  // {
  //   console.log(form.value)
  // }

  username=""

//   profileForm = new FormGroup({
//     name: new FormControl('',Validators.required),
//     email: new FormControl('',Validators.required),
//   });

//   handleSubmit() {
//   alert(
//     this.profileForm.value.name + ' | ' + this.profileForm.value.email
//   );
// }
}
