import { Component, OnInit } from '@angular/core';
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

  constructor(private _playerService: PlayersService,
              private location: Location) { }

  ngOnInit(): void {
    this.getTagCloudFromPlayers();
  }

  getTagCloudFromPlayers(): void{
    this._playerService.getTagCloudFromPlayers().subscribe({

      next: (t) => {this.tagClouds = t,console.log(t)},

    })
  }

  goBack(): void{
    this.location.back();
  }

}
