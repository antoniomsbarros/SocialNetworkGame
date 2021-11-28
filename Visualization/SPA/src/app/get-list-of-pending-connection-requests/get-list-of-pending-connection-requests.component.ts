import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ConnectionIntroductionDTO} from "../DTO/ConnectionIntroductionDTO";
import { Location } from '@angular/common';
@Component({
  selector: 'app-get-list-of-pending-connection-requests',
  templateUrl: './get-list-of-pending-connection-requests.component.html',
  styleUrls: ['./get-list-of-pending-connection-requests.component.css']
})
export class GetListOfPendingConnectionRequestsComponent implements OnInit {


   readonly ROOT_URL="http://localhost:5000/api/IntroductionRequest/";
  listpendingIntroductions: Observable<ConnectionIntroductionDTO[]>| undefined;
  constructor(private http: HttpClient,private location: Location, ) {}

  private client="";

  getPendingIntroductions(){
    this.listpendingIntroductions=this.http.get<ConnectionIntroductionDTO[]>(this.ROOT_URL+"/PlayerIntroduction"+this.client);
  }
  ngOnInit(): void {
    this.getPendingIntroductions();
  }

  goBack() {
    this.location.back();
  }

}
