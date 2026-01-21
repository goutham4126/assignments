import { Component,signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {ReactiveFormsModule,Validators, FormControl, FormGroup,FormBuilder } from '@angular/forms';
@Component({
  selector: 'app-formdemo',
  // imports: [FormsModule],
  imports:[ReactiveFormsModule],
  templateUrl: './formdemo.html',
  styleUrl: './formdemo.css',
})
export class Formdemo {
  // submitForm(form:any)
  // {
  //   console.log(form.value)
  // }

//   name: string = '';
// email: string = '';

// submitForm() {
//   console.log(this.name, this.email);
// }

  // username=""

  // showMessage()
  // {
  // alert(this.username)
  // }

  // profileForm = new FormGroup({
  //   name: new FormControl('',Validators.required),
  //   email: new FormControl('',Validators.required),
  // });

  // handleSubmit() {
  //   alert(
  //     this.profileForm.value.name + ' | ' + this.profileForm.value.email
  //   ); 
  // }

  // profileForm: FormGroup;

  // constructor(private fb: FormBuilder) {
  //   this.profileForm = this.fb.group({
  //     name: ['', Validators.required],
  //     email: ['', [Validators.required, Validators.email]]
  //   });
  // }

  // handleSubmit() {
  //   alert(
  //     this.profileForm.value.name + ' | ' + this.profileForm.value.email
  //   );
  // }

  name = signal('');
  email = signal('');

  submit() {
    console.log(this.name(), this.email());
  }

}
