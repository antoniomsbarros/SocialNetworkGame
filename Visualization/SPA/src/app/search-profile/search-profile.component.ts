import { Component, OnInit } from '@angular/core';
import {PlayersService} from "../services/players/players.service";
import {ActivatedRoute, Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";
import {firstValueFrom} from "rxjs";

@Component({
  selector: 'app-search-profile',
  templateUrl: './search-profile.component.html',
  styleUrls: ['./search-profile.component.css']
})
export class SearchProfileComponent implements OnInit {

  constructor(private playerService: PlayersService, private route: ActivatedRoute,private router:Router,private toastService: ToastrService,) { }

  ngOnInit(): void {

  }
  redorecttoPlayer(){
    // @ts-ignore
    let email=document.getElementById("email").value;
    // @ts-ignore
    document.getElementById("email").value='';
    this.getprofile(email).then(data=>{
        // @ts-ignore
        this.router.navigateByUrl("profile/"+data.email+"/post")
    })
  }
  async getprofile(email:string){
   return await firstValueFrom(this.playerService.getProfile(email));
  }
}
