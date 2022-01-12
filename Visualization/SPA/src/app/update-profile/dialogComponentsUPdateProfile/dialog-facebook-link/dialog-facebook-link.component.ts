import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

export interface DialogData {
  animal: string;
  name: string;
}
@Component({
  selector: 'app-dialog-facebook-link',
  templateUrl: './dialog-facebook-link.component.html',
  styleUrls: ['./dialog-facebook-link.component.css']
})
export class DialogFacebookLinkComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<DialogFacebookLinkComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {
}

ngOnInit(): void {
}

onNoClick(): void {
  this.dialogRef.close();
}

}
