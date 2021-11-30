import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ConnectionIntroductionDTO} from "../DTO/ConnectionIntroductionDTO";
import {Location} from '@angular/common';
import {IntroductionRequestService} from "../introduction-request.service";

@Component({
  selector: 'app-get-list-of-pending-connection-requests',
  templateUrl: './get-list-of-pending-connection-requests.component.html',
  styleUrls: ['./get-list-of-pending-connection-requests.component.css']
})
export class GetListOfPendingConnectionRequestsComponent implements OnInit {


  introductionRequestPending:ConnectionIntroductionDTO[]=[];
  introductionRequestSelected: ConnectionIntroductionDTO | undefined;

   getRandom(){
     return '#' + Math.floor(Math.random() * 16777215).toString(16);
   }
  step = 0;

  setStep(index: number) {
    this.step = index;
  }

  nextStep() {
    this.step++;
  }

  prevStep() {
    this.step--;
  }

  constructor(private http: HttpClient,private location: Location,
              private IntroductionRequestService: IntroductionRequestService) {}


  ngOnInit(): void {
    this.getPendingIntroductions();
  }
  getPendingIntroductions(){
    this.IntroductionRequestService.getIntroductionsPending()
      .subscribe(data=>this.introductionRequestPending=data);
  }

  changeStatus(c: ConnectionIntroductionDTO ){
    this.introductionRequestSelected=c;
    console.log(this.introductionRequestSelected.id);
  }

  goBack() {
    this.location.back();
  }

  Reject() {

  }

  Accept() {

  }
}
