import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
export interface DialogData {
  animal: string;
  name: string;
}
@Component({
  selector: 'app-dialog-full-name',
  templateUrl: './dialog-full-name.component.html',
  styleUrls: ['./dialog-full-name.component.css']
})
export class DialogFullNameComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<DialogFullNameComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {
  }

  ngOnInit(): void {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
