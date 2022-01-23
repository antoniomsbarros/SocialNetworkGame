import {Component, Input, OnInit} from '@angular/core';

import {PlayersService} from "../../services/players/players.service";
import {firstValueFrom} from "rxjs";
import {PlayerDto} from "../../dto/players/PlayerDto";
import {ActivatedRoute} from "@angular/router";
import * as moment from "moment";
import {RelationshipsService} from "../../services/relationships/relationships.service";
import {RelactionShipServiceService} from "../../services/relaction-ship-service.service";

@Component({
  selector: 'app-profile-aboute-me',
  templateUrl: './profile-aboute-me.component.html',
  styleUrls: ['./profile-aboute-me.component.css']
})
export class ProfileAbouteMeComponent implements OnInit {


  player?:PlayerDto;

  constructor(private playerService: PlayersService, private route: ActivatedRoute,private RelationshipsService: RelationshipsService, private RelactionShipServiceService:RelactionShipServiceService) {

  }
  @Input() id:string="";
  currentuser:string="";
  friend:boolean=false;
  numberoflikesdislikes!:number;
  ngOnInit(): void {
    this.currentuser=localStorage.getItem('playeremail')!.trim() || "undefined";
    this.getPlayerProfile();
    this.checkiftheplayerisafriend();
  }

  async getPlayerProfile(){
    this.player= await firstValueFrom(this.playerService.getProfile(this.id));
    console.log(this.player);
    // @ts-ignore
     var divshortname= document.getElementById("divshortName");
    var h4=document.createElement("h4");
    h4.textContent=" Short Name: "+<string>this.player?.shortName;
    h4.style.display ="inline";
    // @ts-ignore
    divshortname.appendChild(h4);

    var divfullname= document.getElementById("divfullName");
    var h4fullname=document.createElement("h4");
    h4fullname.textContent=" Full Name: "+<string>this.player?.fullName;
    h4fullname.style.display ="inline";
    // @ts-ignore
    divfullname.appendChild(h4fullname);


    var divphone= document.getElementById("divphoneNumber");
    var h4phone=document.createElement("h3");
    h4phone.textContent=" "+<string>this.player?.phoneNumber;
    h4phone.style.display ="inline";
    // @ts-ignore
    divphone.appendChild(h4phone);


    var divage= document.getElementById("divage");
    var h4age=document.createElement("h3");
    // @ts-ignore
    let date=new Date( this.player?.dateOfBirth);
    h4age.textContent=" "+<string>moment(date).format('YYYY-MM-DD');;
    h4age.style.display ="inline";
    // @ts-ignore
    divage.appendChild(h4age);


    var divemail= document.getElementById("divemail");
    var h4email=document.createElement("h3");
    h4email.textContent=" "+this.player?.email;
    h4email.style.display ="inline";
    // @ts-ignore
    divemail.appendChild(h4email);


    var divfacebooklinkedin= document.getElementById("facebooklinkdin");
    var h4face=document.createElement("h3");
    h4face.textContent=" "+this.player?.facebookProfile;
    h4face.style.display ="inline";
    // @ts-ignore
    divfacebooklinkedin.appendChild(h4face)

    var divlinkedin= document.getElementById("linkedin");
    var h4link=document.createElement("h3");
    h4link.textContent=" "+this.player?.linkedinProfile;
    h4link.style.display ="inline";
    // @ts-ignore
    divlinkedin.appendChild(h4link)

    var divemocional= document.getElementById("emocional");
    var h4emocional=document.createElement("h3");
    h4emocional.textContent=" Emocional Status : "+this.player?.emotionalStatus+this.addEmots(<string>this.player?.emotionalStatus);
    h4emocional.style.display ="inline";
    // @ts-ignore
    divemocional.appendChild(h4emocional)

  }


  addEmots(emocionalStatus:string):string{
    let result;
    switch (emocionalStatus) {
      case "NotSpecified":
        result="❌";
        break;
      case "Joyful":
        result="😊";
        break;
      case "Distressed":
        result="😩";
        break;
      case "Hopeful":
        result="(θ‿θ)";
        break;
      case "Fearful":
        result="😨";
        break;
      case "Relieve":
        result="😌";
        break;
      case "Disappointed":
        result="😞";
        break;
      case "Proud":
        result="";
        break;
      case "Remorseful":
        result="(*´-｀*)";
        break;
      case "Grateful":
        result="🤗";
        break;
      case "Angry":
        result="😡";
        break;
      default:
        result="NotSpecified";
        break;
    }
    return result;
  }
async getnumberofconnection(){
    let strenght={
      playerIdOrigin: this.id,
      playerIdDest: this.currentuser,
      strength: 0
    }

     return await firstValueFrom(this.RelationshipsService.getConnectionStrenght(strenght))

}
async getfriends(){
    return  await firstValueFrom(this.RelactionShipServiceService.getAllFriendsFromPlayer(this.currentuser));
}
 checkiftheplayerisafriend() {
  this.getfriends().then(data => {
    data.forEach(item => {
      if (item.email === this.id) {
        this.friend = true;
        this.getnumberofconnection().then(r => {
          this.numberoflikesdislikes=r.strength;
        });
      }
    })
  })

}
}
