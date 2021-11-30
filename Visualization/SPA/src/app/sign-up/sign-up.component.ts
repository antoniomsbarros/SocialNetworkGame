import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  registerForm = new FormGroup({
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    number: new FormControl('', [Validators.required, Validators.minLength(10)]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    password1: new FormControl('', [Validators.required, Validators.minLength(8)])
  });

  constructor() {
  }

  ngOnInit(): void {
  }

  get firstName(): any {
    return this.registerForm.get('firstName');
  }

  get lastName(): any {
    return this.registerForm.get('lastName');
  }

  get email(): any {
    return this.registerForm.get('email');
  }

  get number(): any {
    return this.registerForm.get('number');
  }

  get password(): any {
    return this.registerForm.get('password');
  }

  get password1(): any {
    return this.registerForm.get('password1');
  }

  registerFormSubmit(): void {
    const formData = this.registerForm.value;
    delete formData.password1;
    console.log(formData);
    // Api Request Here
  }

}
