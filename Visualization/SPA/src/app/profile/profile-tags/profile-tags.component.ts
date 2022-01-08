import { Component, OnInit } from '@angular/core';
import {CloudData, CloudOptions, TagCloudModule} from 'angular-tag-cloud-module';
import {firstValueFrom} from "rxjs";
import {PlayerDto} from "../../dto/players/PlayerDto";
import {PlayersService} from "../../services/players/players.service";
import {prepareDataForTagCloud} from "./prepareDataForTagCloud";
import {ActivatedRoute} from "@angular/router";


@Component({
  selector: 'app-profile-tags',
  templateUrl: './profile-tags.component.html',
  styleUrls: ['./profile-tags.component.css']
})
export class ProfileTagsComponent implements OnInit {
   userEmail!: any;
  player!:PlayerDto;
  constructor(private playerService: PlayersService,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getPLayerProfile();
  }
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

  data: CloudData[] = [];
  async getPLayerProfile() {
    this.route.params.subscribe(params => {
      this.userEmail = params['email'];
    })
    if (this.userEmail!=null){
      this.player = await firstValueFrom(this.playerService.getProfile(this.userEmail));
    this.data=prepareDataForTagCloud(this.player.tags)
    }
  }

}
