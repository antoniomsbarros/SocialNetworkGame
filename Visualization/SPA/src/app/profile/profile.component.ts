import { Component, OnInit } from '@angular/core';
import {PlayersService} from "../services/players/players.service";
import {PlayerDto} from "../dto/players/PlayerDto";
import {ActivatedRoute, Router} from "@angular/router";
import {firstValueFrom} from "rxjs";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
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
