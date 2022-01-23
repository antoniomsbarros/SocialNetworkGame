import { Component, OnInit } from '@angular/core';
import {RelationshipsService} from "../../services/relationships/relationships.service";
import {PlayerFriendsDTO} from "../../DTO/relationships/PlayerFriendsDTO";
import {RelationshipDto} from "../../DTO/relationships/RelationshipDto";
import {lastValueFrom} from "rxjs";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-profile-friends',
  templateUrl: './profile-friends.component.html',
  styleUrls: ['./profile-friends.component.css']
})
export class ProfileFriendsComponent implements OnInit {
  constructor(private relationshipsservice:RelationshipsService,   private route: ActivatedRoute ) { }
  friends:PlayerFriendsDTO[]=[];
  values:any[][]=[[],[],[]];
  email="Bart92595717@gmail.com";

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.email = params['email'];
    })
    this.preparedata();
  }
 async getfriendsfriends():Promise<PlayerFriendsDTO[]>{
   var cons=[];
   const relactions= this.relationshipsservice.getFriendsFriends(this.email);
   cons=await lastValueFrom(relactions);

   return cons;
  }
  preparedata(){
    let conty=0;
    let contX=0;
    var value=this.getfriendsfriends().then(s=>{
      s.forEach(item=>{
        console.log(item)
        if (item.facebookProfile==="Not specified"){
          console.log("http://facebook.com/")
          item.facebookProfile="http://facebook.com/";
        }
        if (item.linkedinProfile==="Not specified"){
          item.linkedinProfile="https://www.linkedin.com/"
        }
        item.emocionalStatus= this.addEmots(item.emocionalStatus);
        if (conty==3){
          contX+=1;
          conty=0;

          this.values[contX][conty]=item;
          conty++;
        }else {
          this.values[contX][conty]=item;
          conty++;
        }
      })
      console.log(this.values);
    });

  }
  addEmots(emocionalStatus:string):string{

    let result="";
    switch (emocionalStatus) {
      case "NotSpecified":
        result="NotSpecified";
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
  async getNumberOffriendsfriends(email:string){
    var cons=[];
    const relactions=this.relationshipsservice.getRelactionPLayer(email)
    cons=await lastValueFrom(relactions);
    return cons;
  }
  listoffriends(email:any){

   console.log(email)
    return 0;
  }

}
