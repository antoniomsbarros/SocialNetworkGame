import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

export interface DialogData {
  animal: string;
  name: string;
}
@Component({
  selector: 'app-dialog-linkedin-link',
  templateUrl: './dialog-linkedin-link.component.html',
  styleUrls: ['./dialog-linkedin-link.component.css']
})
export class DialogLinkedinLinkComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<DialogLinkedinLinkComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {
  }

  ngOnInit(): void {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
