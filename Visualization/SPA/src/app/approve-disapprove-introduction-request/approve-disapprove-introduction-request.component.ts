import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Location} from "@angular/common";

import {IntroductionRequestService} from "../services/introduction-request.service";
import {ConnectionIntroductionDTO} from "../dto/ConnectionIntroductionDTO";
import {MatSnackBar} from "@angular/material/snack-bar";
import {ActivatedRoute, Router} from "@angular/router";
@Component({
  selector: 'app-approve-disapprove-introduction-request',
  templateUrl: './approve-disapprove-introduction-request.component.html',
  styleUrls: ['./approve-disapprove-introduction-request.component.css']
})
export class ApproveDisapproveIntroductionRequestComponent implements OnInit {

  constructor(private http: HttpClient,private location: Location,
              private IntroductionRequestService: IntroductionRequestService,private _snackBar: MatSnackBar ,private route: ActivatedRoute,private router:Router ) { }

  listofPendingApprovol: ConnectionIntroductionDTO[]=[]
  PendingApprovolSelected: ConnectionIntroductionDTO | undefined ;


  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action);
  }
  ngOnInit(): void {
    console.log(localStorage.getItem('playeremail')!.trim())
    if (localStorage.getItem('playeremail')!.trim()==undefined){
      this.router.navigate(["login"]);
    }

    this.getPendingApprovol();
  }
  getPendingApprovol(){
    this.IntroductionRequestService.getIntroductionPendingAprovall()
      .subscribe(data=>this.listofPendingApprovol=data);
    if (this.listofPendingApprovol.length==0){
      this.openSnackBar("Empty Approval Introductions Requests","close");
    }
  }
  setStep(index: ConnectionIntroductionDTO) {
    this.PendingApprovolSelected=index;
  }
  Accept() {
    if(this.PendingApprovolSelected!=undefined) {
      this.PendingApprovolSelected.connectionRequestStatus=0;
      this.IntroductionRequestService.ApproveDisapproveIntroduction(this.PendingApprovolSelected).subscribe(data=>{
         console.log(data)

        this.openSnackBar("Introduction Request approved","close");

      })
      location.reload();
    }
  }

  Reject() {
    if(this.PendingApprovolSelected!=undefined) {
      this.PendingApprovolSelected.connectionRequestStatus=1;
      this.IntroductionRequestService.ApproveDisapproveIntroduction(this.PendingApprovolSelected).subscribe(data=>{
        console.log(data)
        this.openSnackBar("Introduction Request Rejected","close");
      })
      location.reload();
    }
  }

  goBack() {
  this.location.back();
  }


}
