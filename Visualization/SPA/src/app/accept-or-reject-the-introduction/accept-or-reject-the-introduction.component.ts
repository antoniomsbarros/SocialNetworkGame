import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Location} from "@angular/common";
import {IntroductionRequestService} from "../services/introduction-request.service";
import {ConnectionIntroductionDTO} from "../dto/ConnectionIntroductionDTO";
@Component({
  selector: 'app-accept-or-reject-the-introduction',
  templateUrl: './accept-or-reject-the-introduction.component.html',
  styleUrls: ['./accept-or-reject-the-introduction.component.css']
})
export class AcceptOrRejectTheIntroductionComponent implements OnInit {

  constructor(private http: HttpClient,private location: Location,
              private IntroductionRequestService: IntroductionRequestService, ) { }

  listofPendingApprovol: ConnectionIntroductionDTO[]=[]
  PendingApprovolSelected: ConnectionIntroductionDTO | undefined ;



  ngOnInit(): void {
    this.getPendingApprovol();
  }
  getPendingApprovol(){
    this.IntroductionRequestService.getIntroductionPendingAprovall()
      .subscribe(data=>this.listofPendingApprovol=data);
  }
}
