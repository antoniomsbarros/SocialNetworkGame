import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {RegisterPlayerDto} from "../dto/players/RegisterPlayerDto";
import {PlayersService} from "../services/players/players.service";
import {ToastrService} from "ngx-toastr";
import {HttpErrorResponse} from "@angular/common/http";
import {Router} from "@angular/router";

export enum EmotionalStatus {
  NotSpecified,
  Joyful,
  Distressed,
  Hopeful,
  Fearful,
  Relieve,
  Disappointed,
  Proud,
  Remorseful,
  Grateful,
  Angry
}

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  registerButtonPressed: boolean = false;

  registerPlayerForm = new FormGroup({
    fullName: new FormControl(null),
    shortName: new FormControl(null),
    phoneNumber: new FormControl(null, [Validators.required, Validators.pattern(/[0-9]{9}/)]),
    dateOfBirth: new FormControl(null, [Validators.required]),
    emotionalStatus: new FormControl(null, [Validators.required]),
    email: new FormControl(null, [Validators.required, Validators.email]),
    password: new FormControl(null, [Validators.required]),
    passwordConfirmation: new FormControl(null, [Validators.required]),
    termsConditions: new FormControl(false, [Validators.required, Validators.requiredTrue]),
  });

  constructor(private toastService: ToastrService, private playerService: PlayersService, private router: Router) {
  }

  ngOnInit(): void {
  }

  get isRegisterButtonPressed(): any {
    return this.registerButtonPressed
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
    return this.registerPlayerForm.get('passwordConfirmation');
  }

  get termsConditions(): any {
    return this.registerPlayerForm.get('termsConditions');
  }

  rowEmotionalStatus(): Array<string> {
    const keys = Object.keys(EmotionalStatus);
    return keys.slice(keys.length / 2);
  }

  registerFormSubmit(): void {

    this.registerButtonPressed = true;

    const dto: RegisterPlayerDto =
      {
        email: this.email.value,
        password: this.password.value,
        phoneNumber: this.phoneNumber.value,
        dateOfBirth: new Date(Date.UTC(this.dateOfBirth.value.year, this.dateOfBirth.value.month - 1, this.dateOfBirth.value.day)),
        shortName: this.shortName.value,
        fullName: this.fullName.value,
        emotionalStatus: this.emotionalStatus.value,
      };

    let onNext = () => {
      this.toastService.success("Your account was successfully created!");
      this.router.navigateByUrl('/login');
    };

    let onError = (httpErrorResponse: HttpErrorResponse) => {
      this.registerButtonPressed = false;

      if (httpErrorResponse.status >= 400 && httpErrorResponse.status < 500) {
        if (httpErrorResponse.error["message"] == null)
          this.toastService.error("An unexpected error occured. Please try again");
        else
          this.toastService.error(httpErrorResponse.error["message"]);
      } else
        this.toastService.error("It seems there's a error from our servers. Please try again later");
    }

    this.playerService.registerPlayer(dto)
      .subscribe({
        next() {
          onNext();
        },
        error(error) {
          onError(error);
        }
      });
  }
}
