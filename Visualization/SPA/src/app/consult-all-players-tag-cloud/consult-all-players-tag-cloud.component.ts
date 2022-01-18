import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {PlayersService} from "../services/players/players.service";
import {TagCloud} from "../DTO/TagCloud";
import {Location} from "@angular/common";

@Component({
  selector: 'app-consult-all-players-tag-cloud',
  templateUrl: './consult-all-players-tag-cloud.component.html',
  styleUrls: ['./consult-all-players-tag-cloud.component.css']
})
export class ConsultAllPlayersTagCloudComponent implements OnInit {


  tagClouds: TagCloud[] = [];

  constructor(private route: ActivatedRoute,
              private _playerService: PlayersService,
              private location: Location) { }

  ngOnInit(): void {
    this.getTagCloudFromPlayers();
  }

  getTagCloudFromPlayers(): void{
    this._playerService.getTagCloudFromPlayers().subscribe(t => this.tagClouds = t);
  }

  goBack(): void{
    this.location.back();
  }

}
