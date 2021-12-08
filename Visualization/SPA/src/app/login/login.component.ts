import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthenticationService} from "../services/users/authentication.service";
import {HttpErrorResponse} from "@angular/common/http";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
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

    let onNext = () => {
      this.toastService.success("Player created");
      this.router.navigateByUrl('/network');
    };

    let onError = () => {
      this.toastService.error("Login failed");
    }

    this.authenticationService.login({
      username: this.username?.value,
      password: this.password?.value
    }).subscribe({
      next() {
        onNext();
      },
      error(error) {
        onError();
      }
    });
  }

}
