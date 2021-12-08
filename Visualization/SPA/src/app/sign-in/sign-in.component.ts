import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {RegisterPlayerDto} from "../dto/players/RegisterPlayerDto";
import {PlayersService} from "../services/players/players.service";
import {ToastrService} from "ngx-toastr";
import {PlayerDto} from "../dto/players/PlayerDto";
import {HttpErrorResponse} from "@angular/common/http";
import {Router} from "@angular/router";

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
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

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

  constructor(private toastService: ToastrService, private playerService: PlayersService, private router: Router) {
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
    return this.registerPlayerForm.get('passwordConfirmation');
  }

  public rowEmotionalStatus(): Array<string> {
    const keys = Object.keys(EmotionalStatus);
    return keys.slice(keys.length / 2);
  }

  registerFormSubmit(): void {

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

    let onNext = (player: PlayerDto) => {
      this.toastService.success("Player created");
      this.router.navigateByUrl('/login');
    };

    let onError = (error: HttpErrorResponse) => {
      this.toastService.error(error.error["message"]);
    }

    this.playerService.registerPlayer(dto)
      .subscribe({
        next(player) {
          onNext(player);
        },
        error(error) {
          onError(error);
        }
      });
  }

  clearForm(): void {
    this.registerPlayerForm.reset();
  }

}
