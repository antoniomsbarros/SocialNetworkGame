import {Component, OnInit} from '@angular/core';
import {PlayersService} from "../services/players/players.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {MatDialog} from "@angular/material/dialog";
import {Location} from "@angular/common";
import {CloudOptions} from 'angular-tag-cloud-module';
// @ts-ignore
import {PlayerDto} from "../DTO/players/PlayerDto";
import {TagsDTO} from "../DTO/TagsDTO";
import {firstValueFrom, lastValueFrom} from "rxjs";
import {NgbCalendar, NgbDate, NgbDateStruct, NgbInputDatepickerConfig} from '@ng-bootstrap/ng-bootstrap';
import {DialogFullNameComponent} from "./dialogComponentsUPdateProfile/dialog-full-name/dialog-full-name.component";
import {DialogShortNameComponent} from "./dialogComponentsUPdateProfile/dialog-short-name/dialog-short-name.component";
import {
  DialogPhoneNumberComponent
} from "./dialogComponentsUPdateProfile/dialog-phone-number/dialog-phone-number.component";
import {
  DialogLinkedinLinkComponent
} from "./dialogComponentsUPdateProfile/dialog-linkedin-link/dialog-linkedin-link.component";
import {
  DialogFacebookLinkComponent
} from "./dialogComponentsUPdateProfile/dialog-facebook-link/dialog-facebook-link.component";
import * as moment from "moment";
import {DialogComponent} from "../dialog-component/dialog.component";


@Component({
  selector: 'app-update-profile',
  templateUrl: './update-profile.component.html',
  styleUrls: ['./update-profile.component.css'],
  providers: [NgbInputDatepickerConfig]
})
export class UpdateProfileComponent implements OnInit {
  tags1:string[]=[];
  tagsList: TagsDTO[] = [];
  tagsSelected: string[] = []
  tags = new FormControl();
  data: any[] = [{text: 'Weight-8-link-color', weight: 8, link: 'https://google.com', color: '#ffaaee'},
    {text: 'Weight-10-link', weight: 10, link: 'https://google.com', tooltip: 'display a tooltip'},];
  model: NgbDateStruct | undefined;
  cont:number=0;
  step:number=1;


  constructor(public dialog: MatDialog, private playerService: PlayersService, private location: Location,config: NgbInputDatepickerConfig, calendar: NgbCalendar) {
    // customize default values of datepickers used by this component tree
    var t= moment().subtract(16, 'years').calendar();
    config.minDate = {year: 1900, month: 1, day: 1};
    config.maxDate = {year: 2006, month: 12, day: 31};

    // days that don't belong to current month are not visible
    config.outsideDays = 'hidden';

    // weekends are disabled
    // @ts-ignore
    config.markDisabled = (date: NgbDate) => calendar.getWeekday(date) >= 6;

    // setting datepicker popup to close only on click outside
    config.autoClose = 'outside';

    // setting datepicker popup to open above the input
    config.placement = ['top-left', 'top-right'];

  }

  playerDTO: PlayerDto[] =[];
  email="Bart92595717@gmail.com";
  ngOnInit(): void {
    this.getPersonalData();
    // this.getPersonalData();
    console.log(this.data);
  }

  profile = new FormGroup({
    phoneNumber: new FormControl('', [Validators.pattern(/[0-9]{9}/)]),
    facebookProfile: new FormControl('', []),
    linkedinProfile: new FormControl('', []),
    dateOfBirth: new FormControl('', []),
    shortName: new FormControl('', []),
    fullName: new FormControl('', []),
  });

     async getPersonalData() {
     (await this.playerService.getProfile(this.email)).subscribe((item: PlayerDto) => {

       this.playerDTO.push(item);
       // @ts-ignore
       document.getElementById("id_full_name").value = item.fullName;
       // @ts-ignore
       document.getElementById("id_short_name").value = item.shortName;

       let date=new Date( item.dateOfBirth);
       // @ts-ignore
       document.getElementById("id_date_of_birth").value =moment(date).format('YYYY-MM-DD');
       // @ts-ignore
       document.getElementById("id_phone_number").value = item.phoneNumber;
       // @ts-ignore
       document.getElementById("id_facebook_profile").value = item.facebookProfile;
       // @ts-ignore
       document.getElementById("id_linkedin_profile").value = item.linkedinProfile;
     });

    console.log(this.playerDTO);

   }
 async gettags():Promise<TagsDTO[]>{
     var cons=[];
     const tags12=this.playerService.getPlayersTags(this.email);
     cons=await lastValueFrom(tags12);
     return cons;
 }



  animal: string | undefined;
  name: string | undefined;

  updateProfile() {
    // @ts-ignore
    this.playerDTO[0].dateOfBirth= document.getElementById("id_date_of_birth").value;
    console.log(this.playerDTO[0])

    this.playerService.updateProfile(this.playerDTO[0], this.email).subscribe(data=>{
     this.playerDTO[0]=data;
   });

  }

  goBack(): void {
    this.location.back();
  }
  selected: any;

  changeTags(value: any) {
    this.tagsSelected = value;
    this.playerDTO[0].tags=value;

  }



  openDialog(): void {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '250px',
      data: {name: this.name, animal: this.animal}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != undefined) {
        this.playerDTO[0].tags.push(result);
      }
    });

  }

  openDialogFullName() {
    const dialogRef = this.dialog.open(DialogFullNameComponent, {
      width: '250px',
      data: {name: this.name, animal: this.animal}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != undefined) {
        this.playerDTO[0].fullName=result;
        console.log(this.playerDTO[0].fullName)
        this.cont++;
        // @ts-ignore
        document.getElementById("id_full_name").value = result;

      }
    });
  }

  openDialogshortName() {
    const dialogRef = this.dialog.open(DialogShortNameComponent, {
      width: '250px',
      data: {name: this.name, animal: this.animal}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != undefined) {
        this.playerDTO[0].shortName=result;
        console.log(this.playerDTO[0].shortName)
        this.cont++;
        // @ts-ignore
        document.getElementById("id_short_name").value = result;

      }
    });
  }

  openDialogid_phone_number() {
    const dialogRef = this.dialog.open(DialogPhoneNumberComponent, {
      width: '270px',
      data: {name: this.name, animal: this.animal}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != undefined) {
        this.playerDTO[0].phoneNumber=result;
        console.log(this.playerDTO[0].phoneNumber)
        this.cont++;
        // @ts-ignore
        document.getElementById("id_phone_number").value = result;

      }
    });
  }

  openDialogid_facebook_profile() {
    const dialogRef = this.dialog.open(DialogFacebookLinkComponent, {
      width: '270px',
      data: {name: this.name, animal: this.animal}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != undefined) {
        this.playerDTO[0].facebookProfile=result;
        console.log(this.playerDTO[0].facebookProfile)
        this.cont++;
        // @ts-ignore
        document.getElementById("id_facebook_profile").value = result;

      }
    });
  }

  openDialogid_linkedin_profile() {
    const dialogRef = this.dialog.open(DialogLinkedinLinkComponent, {
      width: '270px',
      data: {name: this.name, animal: this.animal}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != undefined) {
        this.playerDTO[0].linkedinProfile=result;
        console.log(this.playerDTO[0].linkedinProfile)
        this.cont++;
        // @ts-ignore
        document.getElementById("id_linkedin_profile").value = result;
      }
    });
  }

  datachange() {
    // @ts-ignore
    this.playerDTO[0].dateOfBirth= document.getElementById("id_date_of_birth").value;
  }
}
