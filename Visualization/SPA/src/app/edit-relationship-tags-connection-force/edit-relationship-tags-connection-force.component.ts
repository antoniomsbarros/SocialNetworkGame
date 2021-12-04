import { Component, OnInit } from '@angular/core';
import {FormControl} from "@angular/forms";
import {Location} from "@angular/common";

@Component({
  selector: 'app-edit-relationship-tags-connection-force',
  templateUrl: './edit-relationship-tags-connection-force.component.html',
  styleUrls: ['./edit-relationship-tags-connection-force.component.css']
})
export class EditRelationshipTagsConnectionForceComponent implements OnInit {

  tags = new FormControl();
  tagsList: string[] =[];
  tagsSelected:string[]=[];
  connectionStrength:any;

  constructor(private location: Location) { }

  ngOnInit(): void {
  }

  changeTags(value: any) {
    this.tagsSelected= value;
  }


  goBack(): void {
    this.location.back();
  }
}
