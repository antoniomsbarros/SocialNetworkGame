import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ConnectionIntroductionDTO} from "../dto/ConnectionIntroductionDTO";
import { Location } from '@angular/common';
import {IntroductionRequestService} from "../introduction-request.service";

@Component({
  selector: 'app-get-list-of-pending-connection-requests',
  templateUrl: './get-list-of-pending-connection-requests.component.html',
  styleUrls: ['./get-list-of-pending-connection-requests.component.css']
})
export class GetListOfPendingConnectionRequestsComponent implements OnInit {


   readonly ROOT_URL="http://localhost:5000/api/IntroductionRequest/";
  constructor(private http: HttpClient,private location: Location,
              private IntroductionRequestService: IntroductionRequestService) {}

  introductionRequestPending:ConnectionIntroductionDTO[]=[];

  getPendingIntroductions(){
      this.IntroductionRequestService.getIntroductionsPending()
        .subscribe(introductionRequestPending=>this.introductionRequestPending=introductionRequestPending);
  }
  ngOnInit(): void {
    this.getPendingIntroductions();
  }

  goBack() {
    this.location.back();
  }

}
