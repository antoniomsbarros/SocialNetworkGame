import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";

export enum EmotionalStatus {
  // excited
  Astonishment,
  Eagerness,
  Curiosity,

  Inspiration,
  Desire,
  Love,

  // pleasant
  Fascination,
  Admiration,
  Joyfulness,

  Satisfaction,
  Softened,
  Relaxed,

  // calm
  Awaiting,
  Deferent,
  Calm,

  Boredom,
  Sadness,
  Isolation,

  // unpleasant
  Disappointment,
  Contempt,
  Jealousy,

  Irritation,
  Disgust,
  Alarm
}


@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  registerPlayerForm = new FormGroup({
    fullName: new FormControl(''),
    shortName: new FormControl(''),
    phoneNumber: new FormControl('', [Validators.required, Validators.pattern(/[0-9]{9}/)]),
    dateOfBirth: new FormControl('', [Validators.required]),
    emotionalStatus: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
    passwordConfirmation: new FormControl('', [Validators.required])
  });

  constructor() {
  }

  ngOnInit(): void {
  }

  get fullName(): any {
    return this.registerPlayerForm.get('fullName');
  }

  get shortName(): any {
    return this.registerPlayerForm.get('shortName');
  }

  get email(): any {
    return this.registerPlayerForm.get('email');
  }

  get phoneNumber(): any {
    return this.registerPlayerForm.get('phoneNumber');
  }

  get dateOfBirth(): any {
    return this.registerPlayerForm.get('dateOfBirth');
  }

  get emotionalStatus(): any {
    return this.registerPlayerForm.get('emotionalStatus');
  }

  get password(): any {
    return this.registerPlayerForm.get('password');
  }

  get passwordConfirmation(): any {
    return this.registerPlayerForm.get('password1');
  }

  public rowEmotionalStatus(): Array<string> {
    const keys = Object.keys(EmotionalStatus);
    console.log(keys.slice(keys.length / 2));
    return keys.slice(keys.length / 2);
  }

  registerFormSubmit(): void {
    const formData = this.registerPlayerForm.value;
    delete formData.password1;
    console.log(formData);
    // Api Request Here
  }
}
