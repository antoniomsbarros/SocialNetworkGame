import { Component, OnInit } from '@angular/core';
import {PlayersService} from "../services/players/players.service";
import {Location} from "@angular/common";
import {CloudData, CloudOptions} from 'angular-tag-cloud-module';
import { prepareDataForTagCloudWeighted} from "../profile/profile-tags/prepareDataForTagCloud";

@Component({
  selector: 'app-consult-all-players-tag-cloud',
  templateUrl: './consult-all-players-tag-cloud.component.html',
  styleUrls: ['./consult-all-players-tag-cloud.component.css']
})
export class ConsultAllPlayersTagCloudComponent implements OnInit {
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
  constructor(private _playerService: PlayersService,
              private location: Location) { }

  ngOnInit(): void {
    this._playerService.getTagCloudFromPlayers().subscribe(t => {
      this.data = prepareDataForTagCloudWeighted(t);
    });
  }



  goBack(): void{
    this.location.back();
  }

}
