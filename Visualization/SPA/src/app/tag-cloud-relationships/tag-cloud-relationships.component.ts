import { Component, OnInit } from '@angular/core';
import {RelationshipsService} from "../services/relationships/relationships.service";
import {RelationshipDto} from "../DTO/relationships/RelationshipDto";
import {TagsDTO} from "../DTO/TagsDTO";
import {lastValueFrom} from "rxjs";
import {CloudData, CloudOptions} from "angular-tag-cloud-module";
import {prepareDataForTagCloud} from "../profile/profile-tags/prepareDataForTagCloud";

@Component({
  selector: 'app-tag-cloud-relationships',
  templateUrl: './tag-cloud-relationships.component.html',
  styleUrls: ['./tag-cloud-relationships.component.css']
})
export class TagCloudRelationshipsComponent implements OnInit {

  constructor( private relationshipsservice:RelationshipsService ) { }
  relactionships!:RelationshipDto[]
  tags:string[]=[];
  ngOnInit(): void {
    this.getRelationships().then(s=>{
      console.log(s);
      this.relactionships=s;
      this.getTags();
      console.log(this.tags)
    });
    console.log(this.relactionships);
  }
  email="Bart92595717@gmail.com"
  async getRelationships():Promise<RelationshipDto[]>{
    var cons=[];
    const relactions= this.relationshipsservice.getRelactionPLayer(this.email);
    cons=await lastValueFrom(relactions);
    return cons;
  }
  getTags(){
    for (let i = 0; i < this.relactionships.length; i++) {
      for (let j = 0; j < this.relactionships[i].tags.length; j++) {
        console.log(this.relactionships[i].tags[j]);

        this.tags.push(this.relactionships[i].tags[j]);
      }
    }
    this.data=prepareDataForTagCloud(this.tags);
  }
  options: CloudOptions = {
    width: 1,
    height: 500,
    overflow: false,
    zoomOnHover:{
      scale:1.2,
      transitionTime:0.3,
      delay:0.3
    },
    realignOnResize:true
  };

  data: CloudData[] = [];
}
