import { Component, OnInit } from '@angular/core';
import {PlayersService} from "../services/players/players.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {DialogComponent} from "../dialog-component/dialog.component";
import {MatDialog} from "@angular/material/dialog";
import {Location} from "@angular/common";


@Component({
  selector: 'app-update-profile',
  templateUrl: './update-profile.component.html',
  styleUrls: ['./update-profile.component.css']
})
export class UpdateProfileComponent implements OnInit {
  constructor(public dialog: MatDialog, private playerService: PlayersService, private location: Location) { }

  ngOnInit(): void {
  }


  tagsList: string[] = [];
  tagsSelected: string[] = []
  tags = new FormControl();

  profile = new FormGroup({
    phoneNumber: new FormControl('', [Validators.pattern(/[0-9]{9}/)]),
    facebookProfile: new FormControl('', []),
    linkedinProfile: new FormControl('', []),
    dateOfBirth: new FormControl('', []),
    shortName: new FormControl('', []),
    fullName: new FormControl('', []),
  });


  changeTags(value: any) {
    this.tagsSelected = value;
  }

  animal: string | undefined;
  name: string | undefined;

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '250px',
      data: {name: this.name, animal: this.animal}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != undefined) {
        this.tagsList.push(result);
      }
    });

  }

  updateProfile() {
    let sessionEmail = localStorage.getItem('id');
    if (!sessionEmail) return;
    this.playerService.updateProfile({
      email: sessionEmail,
      dateOfBirth: this.profile.value.dateOfBirth == "" ? null : this.profile.value.dateOfBirth,
      facebookProfile: this.profile.value.facebookProfile == "" ? null : this.profile.value.facebookProfile,
      fullName: this.profile.value.fullName == "" ? null : this.profile.value.fullName,
      linkedinProfile: this.profile.value.linkedinProfile == "" ? null : this.profile.value.linkedinProfile,
      phoneNumber: this.profile.value.phoneNumber == "" ? null : this.profile.value.phoneNumber,
      shortName: this.profile.value.shortName == "" ? null : this.profile.value.shortName,
      tags: this.tagsSelected,
    }).subscribe(dto => {
      console.log(dto);
    });
  }

  goBack(): void {
    this.location.back();
  }
}
