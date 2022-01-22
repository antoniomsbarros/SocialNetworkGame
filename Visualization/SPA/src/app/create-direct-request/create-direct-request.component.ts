import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {DialogComponent} from "../dialog-component/dialog.component";
import {MatDialog} from "@angular/material/dialog";
import {DirectRequestService} from "../services/directrequests/direct-request.service";
import {CreateDirectRequestDto} from "../dto/directrequests/CreateDirectRequestDto";

@Component({
  selector: 'app-create-direct-request',
  templateUrl: './create-direct-request.component.html',
  styleUrls: ['./create-direct-request.component.css']
})
export class CreateDirectRequestComponent implements OnInit {

  minConnectionStrength: number = 1;
  maxConnectionStrength: number = 100;
  toppingList: string[] = [];
  tagsSelected: string[] = []
  toppings = new FormControl();

  createDirectRequestForm = new FormGroup({
    playerToAdd: new FormControl('', [Validators.required]),
    connectionStrength: new FormControl('',
      [Validators.required, Validators.min(this.minConnectionStrength), Validators.max(this.maxConnectionStrength)]),
    requestText: new FormControl('', [Validators.required]),
  });

  constructor(public dialog: MatDialog, public directRequestService: DirectRequestService) {
  }

  ngOnInit(): void {
  }

  get playerToAdd(): any {
    return this.createDirectRequestForm.get('playerToAdd');
  }

  get connectionStrength(): any {
    return this.createDirectRequestForm.get('connectionStrength');
  }

  get requestText(): any {
    return this.createDirectRequestForm.get('requestText');
  }

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
        this.toppingList.push(result);
      }
    });

  }

  createDirectRequestFormSubmit(): void {
    const dto: CreateDirectRequestDto =
      {
        playerSender: localStorage.getItem('playeremail')!.trim(), // User authenticated email
        playerReceiver: this.playerToAdd.value,
        text: this.requestText.value,
        connectionStrength: this.connectionStrength.value,
        tags: this.tagsSelected,
      };

    let directRequestDto;

    this.directRequestService.createDirectRequest(dto)
      .subscribe(dtoAnswer => directRequestDto = dtoAnswer);

    // Add validation
  }

}
