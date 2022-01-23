import { Component, OnInit } from '@angular/core';
import {PlayersService} from "../services/players/players.service";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";
import {AuthenticationService} from "../services/users/authentication.service";

@Component({
  selector: 'app-delete-account',
  templateUrl: './delete-account.component.html',
  styleUrls: ['./delete-account.component.css']
})
export class DeleteAccountComponent implements OnInit {

  constructor(private playerService: PlayersService,
              private toastrService: ToastrService,
              private router: Router,
              private authenticationService: AuthenticationService) { }

  ngOnInit(): void {
  }

  deleteAccount() {
    let user = this.playerService.getCurrentLoggedInUser();
    this.playerService.deleteAccount(user).subscribe(r => {
      this.toastrService.success("Account removed")
      this.authenticationService.logout()
      this.router.navigateByUrl('/login').then(r => {
        this.authenticationService.logout()
      })
    });
  }
}
