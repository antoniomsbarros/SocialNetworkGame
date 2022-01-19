import {Component, Input, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthenticationService} from "../services/users/authentication.service";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @Input() recentUser?: string;

  isLoginButtonPressed: boolean = false;

  loginForm = new FormGroup({
      username: new FormControl(this.recentUser, [Validators.required]),
      password: new FormControl(null, [Validators.required])
    }
  );

  constructor(private toastService: ToastrService, private router: Router, private authenticationService: AuthenticationService) {
  }

  get username() {
    return this.loginForm.get("username");
  }

  get password() {
    return this.loginForm.get("password");
  }

  ngOnInit(): void {
  }

  login(): void {

    this.isLoginButtonPressed = true;

    let onNext = () => {
      this.toastService.success("Successfully logged in!");
      this.navigateToMainPage();
    };

    let onError = (httpErrorResponse: HttpErrorResponse) => {
      if (httpErrorResponse.status >= 400 && httpErrorResponse.status < 500)
        this.toastService.error(httpErrorResponse.error["message"]);
      else
        this.toastService.error("Failed to login! Please try again");

      this.isLoginButtonPressed = false;
    }

    this.authenticationService.login({
      username: this.username?.value,
      password: this.password?.value
    }).subscribe({
      next() {
        onNext();
      },
      error(error) {
        onError(error);
      }
    });

    localStorage.clear();
    // @ts-ignore
    localStorage.setItem('playeremail', this.username?.value);
  }

  navigateToMainPage() {
    this.router.navigateByUrl('/network');
  }

}
