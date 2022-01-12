import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

export interface DialogData {
  animal: string;
  name: string;
}
@Component({
  selector: 'app-dialog-short-name',
  templateUrl: './dialog-short-name.component.html',
  styleUrls: ['./dialog-short-name.component.css']
})
export class DialogShortNameComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<DialogShortNameComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {
  }

  ngOnInit(): void {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
