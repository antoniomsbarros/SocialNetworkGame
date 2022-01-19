import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {TagCloud} from "../DTO/TagCloud";
import {RelationshipsService} from "../services/relationships/relationships.service";
import {Location} from "@angular/common";

@Component({
  selector: 'app-consult-all-relationships-tag-cloud',
  templateUrl: './consult-all-relationships-tag-cloud.component.html',
  styleUrls: ['./consult-all-relationships-tag-cloud.component.css']
})
export class ConsultAllRelationshipsTagCloudComponent implements OnInit {

  tagClouds: TagCloud[] = [];

  constructor(private route: ActivatedRoute,
              private _RelationshipService: RelationshipsService,
              private location: Location) { }

  ngOnInit(): void {
    this.getTagCloudFromRelationships();
  }

  getTagCloudFromRelationships(): void{
    this._RelationshipService.getTagCloudFromRelationships().subscribe(t => this.tagClouds = t);
  }

  goBack(): void{
    this.location.back();
  }

}
