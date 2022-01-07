import {Component, Input, OnInit} from '@angular/core';

import {PlayersService} from "../../services/players/players.service";
import {firstValueFrom} from "rxjs";
import {PlayerDto} from "../../dto/players/PlayerDto";
import {ActivatedRoute} from "@angular/router";
import * as moment from "moment";
@Component({
  selector: 'app-profile-aboute-me',
  templateUrl: './profile-aboute-me.component.html',
  styleUrls: ['./profile-aboute-me.component.css']
})
export class ProfileAbouteMeComponent implements OnInit {


  player?:PlayerDto;

  constructor(private playerService: PlayersService, private route: ActivatedRoute) {

  }
  @Input() id:string="";
  ngOnInit(): void {
    this.getPlayerProfile();
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
    h4phone.textContent=" Phone Number: "+<string>this.player?.phoneNumber;
    h4phone.style.display ="inline";
    // @ts-ignore
    divphone.appendChild(h4phone);


    var divage= document.getElementById("divage");
    var h4age=document.createElement("h3");
    // @ts-ignore
    let date=new Date( this.player?.dateOfBirth);
    h4age.textContent=" Birth Date: "+<string>moment(date).format('YYYY-MM-DD');;
    h4age.style.display ="inline";
    // @ts-ignore
    divage.appendChild(h4age);


    var divemail= document.getElementById("divemail");
    var h4email=document.createElement("h3");
    h4email.textContent=" Email: "+this.player?.email;
    h4email.style.display ="inline";
    // @ts-ignore
    divemail.appendChild(h4email);


    var divfacebooklinkedin= document.getElementById("facebooklinkdin");
    var h4face=document.createElement("h3");
    h4face.textContent=" Facebook : "+this.player?.facebookProfile;
    h4face.style.display ="inline";
    // @ts-ignore
    divfacebooklinkedin.appendChild(h4face)

    var divlinkedin= document.getElementById("linkedin");
    var h4link=document.createElement("h3");
    h4link.textContent=" Facebook : "+this.player?.linkedinProfile;
    h4link.style.display ="inline";
    // @ts-ignore
    divlinkedin.appendChild(h4link)

    var divemocional= document.getElementById("emocional");
    var h4emocional=document.createElement("h3");
    h4emocional.textContent=" Emocional Status : "+this.player?.emotionalStatus;
    h4emocional.style.display ="inline";
    // @ts-ignore
    divemocional.appendChild(h4emocional)

  }

}
