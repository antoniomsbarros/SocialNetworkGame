import {Component, Input, OnInit} from '@angular/core';
import {PlayerDto} from "../../dto/players/PlayerDto";
import {PlayersService} from "../../services/players/players.service";
import {firstValueFrom} from "rxjs";



@Component({
  selector: 'app-profile-header',
  templateUrl: './profile-header.component.html',
  styleUrls: ['./profile-header.component.css']
})
export class ProfileHeaderComponent implements OnInit {

  player?: PlayerDto ;
 @Input() id:string="";
  constructor(private playerService: PlayersService) {

  }
  name:string="PLayer"
  ngOnInit(): void {
    this.getProfilePLayer();
  }

  async getProfilePLayer() {
    this.player =await firstValueFrom(this.playerService.getProfile(this.id));

    if (this.player?.facebookProfile==="Not specified"){
      // @ts-ignore
      document.getElementById("facebook-link").setAttribute('href',"http://facebook.com" );
    }else {
      // @ts-ignore
      document.getElementById("facebook-link").setAttribute('href',this.player?.facebookProfile );
    }
    if (this.player?.linkedinProfile==="Not specified"){
      // @ts-ignore
      document.getElementById("linkedin-link").setAttribute('href',"https://www.linkedin.com/" );
    }else {
      // @ts-ignore
      document.getElementById("linkedin-link").setAttribute('href',this.player?.linkedinProfile );
    }
    if (this.player?.phoneNumber.length==0){
      // @ts-ignore
      document.getElementById("phoneNumber").setAttribute('title',"Not specified" );
    }else {
      // @ts-ignore
      document.getElementById("phoneNumber").setAttribute('title',this.player?.phoneNumber );
    }
    if (this.player?.email.length==0){
      // @ts-ignore
      document.getElementById("email-link").setAttribute('title',"Not specified" );
    }else {
      // @ts-ignore
      document.getElementById("email-link").setAttribute('title',this.player?.email );
    }
    if (this.player?.fullName.length!=0){
     this.name=<string>this.player?.fullName
    }

  }
}
