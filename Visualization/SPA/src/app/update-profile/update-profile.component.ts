import { Component, OnInit } from '@angular/core';
import {PlayersService} from "../services/players/players.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-update-profile',
  templateUrl: './update-profile.component.html',
  styleUrls: ['./update-profile.component.css']
})
export class UpdateProfileComponent implements OnInit {
  tags = new FormControl();


  profile = new FormGroup({
    phoneNumber: new FormControl('', [Validators.pattern(/[0-9]{9}/)]),
    facebookProfile: new FormControl('', []),
    linkedinProfile: new FormControl('', []),
    dateOfBirth: new FormControl('', []),
    tags: new FormControl('', []),




  });

  constructor(private playerService: PlayersService) { }

  ngOnInit(): void {
  }

}
