import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

export interface DialogData {
  animal: string;
  name: string;
}
@Component({
  selector: 'app-dialog-phone-number',
  templateUrl: './dialog-phone-number.component.html',
  styleUrls: ['./dialog-phone-number.component.css']
})
export class DialogPhoneNumberComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<DialogPhoneNumberComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {
  }

  ngOnInit(): void {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
