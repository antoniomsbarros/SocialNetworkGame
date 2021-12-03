import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { IDropdownSettings } from 'ng-multiselect-dropdown';

import {ConnectionIntroductionDTO} from "../dto/ConnectionIntroductionDTO";
import {Location} from '@angular/common';
import {IntroductionRequestService} from '../services/introduction-request.service';
import {TagsDTO} from "../DTO/TagsDTO";
import {TagsService} from "../services/tags.service";
import {MatSnackBar} from "@angular/material/snack-bar";




@Component({
  selector: 'app-get-list-of-pending-connection-requests',
  templateUrl: './get-list-of-pending-connection-requests.component.html',
  styleUrls: ['./get-list-of-pending-connection-requests.component.css']
})
export class GetListOfPendingConnectionRequestsComponent implements OnInit {

  introductionRequestPending:ConnectionIntroductionDTO[]=[];
  introductionRequestSelected: ConnectionIntroductionDTO | undefined;
  allTags:TagsDTO[]=[];
  dropdownList:any  = [];
  selectedItems:any = [];
  dropdownSettings :IDropdownSettings={};
  ola:number=1;
  ConnectionStringh: number | undefined;
  selectedTags: string[]=[];

   client = "1200607@isep.ipp.pt";
  constructor(private http: HttpClient,private location: Location,
              private IntroductionRequestService: IntroductionRequestService,
              private TagService: TagsService,private _snackBar: MatSnackBar) {

  }

  ngOnInit(): void {

    this.getPendingIntroductions();


    this.selectedItems = [];
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 8,
      allowSearchFilter: true,
      maxHeight: 100,
      enableCheckAll: false,

    };

  }

  onItemSelect(item: any) {
    this.selectedTags.push(item.item_text);
  }
  onSelectAll(items: any) {
    console.log(items);
  }


  setStep(index: ConnectionIntroductionDTO) {
    this.introductionRequestSelected = index;
  }

  getPendingIntroductions(){
     this.IntroductionRequestService.getAllTags()
      .subscribe(data=>{
        // @ts-ignore
        data.forEach(item=>{
          this.allTags.push(item);
          this.dropdownList.push({ item_id:this.ola++, item_text: item.name})
        })
      });

    this.IntroductionRequestService.getIntroductionsPending(this.client)
      .subscribe(data=>this.introductionRequestPending=data);

  }


  goBack() {
    this.location.back();
  }
  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action);
  }
  Reject() {
    if (this.introductionRequestSelected!= undefined){
      this.introductionRequestSelected.introductionStatus=1;
      this.IntroductionRequestService.AcceptorrejectIntroduction(this.introductionRequestSelected).subscribe(data=>this.introductionRequestSelected=data);
      console.log(this.introductionRequestSelected.id);
      this.openSnackBar("Introduction Request Rejected","close");
      this.getPendingIntroductions();

     location.reload();
    }
  }

  Accept() {
    if (this.introductionRequestSelected!= undefined){
      this.introductionRequestSelected.introductionStatus=0;

      this.introductionRequestSelected.tags=[];
      for (let i = 0; i < this.selectedTags.length; i++) {
        this.introductionRequestSelected.tags.push(this.selectedTags[i]);
      }
      this.ConnectionStringh= Number((document.getElementById("ConnectionStrenght") as HTMLInputElement).value);
      if (this.ConnectionStringh==null){
        alert("Is requeried to define a number between 0 and 100")
      }else {
        this.introductionRequestSelected.connectionStrengthConf = this.ConnectionStringh;
      }
      this.selectedTags=[];
      console.log(this.introductionRequestSelected)
      this.IntroductionRequestService.AcceptorrejectIntroduction(this.introductionRequestSelected).subscribe(data=>this.introductionRequestSelected=data);
      console.log(this.introductionRequestSelected.id);
      this.openSnackBar("Introduction Request accept","close");

      this.getPendingIntroductions();
      location.reload()
    }
  }
}
