import { Component, OnInit } from '@angular/core';
import {TagCloud} from "../DTO/TagCloud";
import {RelationshipsService} from "../services/relationships/relationships.service";
import {Location} from "@angular/common";
import {CloudData, CloudOptions} from 'angular-tag-cloud-module';
import { prepareDataForTagCloudWeighted} from "../profile/profile-tags/prepareDataForTagCloud";

@Component({
  selector: 'app-consult-all-relationships-tag-cloud',
  templateUrl: './consult-all-relationships-tag-cloud.component.html',
  styleUrls: ['./consult-all-relationships-tag-cloud.component.css']
})
export class ConsultAllRelationshipsTagCloudComponent implements OnInit {
  data: CloudData[] = [];
  options: CloudOptions = {
    width: 1,
    height: 200,
    overflow: false,
    zoomOnHover:{
      scale:1.2,
      transitionTime:0.3,
      delay:0.3
    },
    realignOnResize:true
  };

  constructor(private _RelationshipService: RelationshipsService,
              private location: Location) { }

  ngOnInit(): void {
    this._RelationshipService.getTagCloudFromRelationships().subscribe(t => {
      this.data = prepareDataForTagCloudWeighted(t);
    });
  }


  goBack(): void{
    this.location.back();
  }

}
