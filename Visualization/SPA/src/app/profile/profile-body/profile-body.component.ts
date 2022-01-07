import { Component, OnInit } from '@angular/core';
import {PlayersService} from "../../services/players/players.service";
import {ActivatedRoute, Router} from "@angular/router";
import {PlayerDto} from "../../dto/players/PlayerDto";

import {firstValueFrom} from "rxjs";

@Component({
  selector: 'app-profile-body',
  templateUrl: './profile-body.component.html',
  styleUrls: ['./profile-body.component.css']
})
export class ProfileBodyComponent implements OnInit {

  email:string="Bart92595717@gmail.com";
  id:string =""
  constructor(private playerService: PlayersService, private route: ActivatedRoute,private router:Router) { }

  player!: PlayerDto;
  ngOnInit(): void {
    this.getPLayerProfile();
  }
  async getPLayerProfile() {

    // @ts-ignore
    this.id = this.route.snapshot.paramMap.get('id');

    if (this.id!=null){
      this.player = await firstValueFrom(this.playerService.getProfile(this.id));
    }else {
      this.player =  await firstValueFrom(this.playerService.getProfile(this.email));
    }

  }

  changeActivitys() {
    this.router.navigate(["post"],{relativeTo:this.route});
  }


  changeFriends() {
    this.router.navigate(["friends"],{relativeTo:this.route});
  }

  changeTags() {
    this.router.navigate(["tags"],{relativeTo:this.route});
  }
}
