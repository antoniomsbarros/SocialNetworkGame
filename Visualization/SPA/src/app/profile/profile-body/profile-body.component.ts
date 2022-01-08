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
  currentTab!:string;
  player!: PlayerDto;
  ngOnInit(): void {
    this.getPLayerProfile();
    this.checkCurrentTab();
  }
  async getPLayerProfile() {

    // @ts-ignore
    this.id = this.route.snapshot.paramMap.get('email');
   console.log(this.id);
    if (this.id!=null){
      this.player = await firstValueFrom(this.playerService.getProfile(this.id));
    }else {
      this.player =  await firstValueFrom(this.playerService.getProfile(this.email));
    }

  }

  checkCurrentTab() {
    let tab = this.router.url.substring(this.router.url.lastIndexOf('/') + 1);
    if(tab == "post") {
      this.currentTab = "Activity";
    } else if (tab == "friends") {
      this.currentTab = "friends";
    } else if (tab == "tags") {
      console.log("Aqui")
      this.currentTab = "tags";
    }
  }

  changeActive(event: any) {
    var navs = document.getElementsByClassName("nav nav-tabs");
    for(let i = 0; i < navs[0].children.length; i++) {
      if(navs[0].children[i].id!= event.target.id) {
        navs[0].children[i].classList.remove('active');
      }
    }
    event.target.classList.add('active');
  }
}
