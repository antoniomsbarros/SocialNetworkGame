import {Component, Inject, NgModule, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Location} from "@angular/common";
import {TagsService} from "../services/tags.service";
import {IntroductionRequestService} from "../services/introduction-request.service";
import {RelactionShipServiceService} from "../services/relaction-ship-service.service";
import {PlayerEmailDto} from "../DTO/PlayerEmailDto";
import {TagsDTO} from "../DTO/TagsDTO";
import {FormControl} from "@angular/forms";
import {MatSnackBar} from "@angular/material/snack-bar";
import {MAT_DIALOG_DATA, MatDialog, MatDialogRef} from "@angular/material/dialog";
import {DialogComponent} from "../dialog-component/dialog.component";

@Component({
  selector: 'app-create-introduction',
  templateUrl: './create-introduction.component.html',
  styleUrls: ['./create-introduction.component.css']
})
export class CreateIntroductionComponent implements OnInit {
  introductionRequestPending: any;
  selectedValue: any;

  private client: string = "Katherine42584467@gmail.com";
  Friends: PlayerEmailDto[] = [];
  FriendsofFriends: PlayerEmailDto[] = [];
  AllTags: TagsDTO[] = [];
  ola: number = 1


  toppings = new FormControl();
  toppingList: string[] = [];
  tagsSelected: string[] = []
  textintroduction: any;
  textaproved: any;
  connectionStrenght: any;

  playerreciver: any;
  playerintroducting: any;

  constructor(private http: HttpClient, private location: Location,
              private IntroductionRequestService: IntroductionRequestService,
              private TagService: TagsService, private RelactionshipService: RelactionShipServiceService,
              private _snackBar: MatSnackBar, public dialog: MatDialog) {

  }

  ngOnInit(): void {
    this.get();
    this.getFriends();
  }

  getFriends() {
    //let sessionEmail = localStorage.getItem('id');
   // console.log(sessionEmail)
    this.ola = 0;
    this.RelactionshipService.getAllFriendsFromPlayer(this.client).subscribe(data => {
      data.forEach(item => {
        console.log(item)
        this.Friends.push({email: item.email, name: item.name})

      })
    })
  }

  getFriendsofFriends(friendenmail: string) {
    this.ola = 0;
    this.RelactionshipService.getAllFriendsFromPlayer(friendenmail).subscribe(data => {
      data.forEach(item => {
        if (item.email != this.client) {
          this.FriendsofFriends.push({email: item.email, name: item.name})

        }
      })
    })

  }

  get() {
    this.ola = 1;
    this.IntroductionRequestService.getAllTags()
      .subscribe(data => {
        // @ts-ignore
        data.forEach(item => {
          this.AllTags.push(item);
          this.toppingList.push(item.name)
          console.log(item);
        })
      });
  }


  changeFriend(country: any) {
    this.playerreciver = country.value;
    this.getFriendsofFriends(country.value);
  }


  changefriendoffriend(state: any) {
    this.playerintroducting = state.value;

  }

  goBack() {
    this.location.back()
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action);
  }

  create() {
    var message;
    var count = 0
    if (this.playerreciver == null) {
      this.openSnackBar("The Friend cant be Empty", "close");
      count++
    }
    if (this.playerintroducting == null && count == 0) {
      this.openSnackBar("The Friend of the Friend cant be Empty", "close");
      count++;
    }
    if (this.textintroduction == null && count == 0) {
      this.openSnackBar("the Introduction Message cant be Empty", "close");
      count++;
    }
    if (this.textaproved == null && count == 0) {
      this.openSnackBar("the Approvol Message cant be Empty", "close");
      count++;
    }
    if (this.connectionStrenght == null && count == 0) {
      this.openSnackBar("the Connection Strenght cant be Empty", "close");
      count++;
    }
    if (this.connectionStrenght > 100 && count == 0) {
      this.openSnackBar("the Connection Strenght cant be  Greater then 100", "close");
      count++;
    }
    if (this.connectionStrenght < 1 && count == 0) {
      this.openSnackBar("the Connection Strenght cant be  less than one", "close");
      count++;
    }
    if (this.tagsSelected.length == 0 && count == 0) {
      this.openSnackBar("The tags cant be Empty", "close");
      count++;
    }
    if (count == 0) {
      var ConnectionIntroductionCreate
      ConnectionIntroductionCreate = {
        PlayerSender: this.client,
        PlayerReceiver: this.playerreciver,
        PlayerIntroduction: this.playerintroducting,
        Text: this.textaproved,
        TextIntroduction: this.textintroduction,
        ConnectionStrength: this.connectionStrenght,
        Tags: this.tagsSelected
      }
      console.log(ConnectionIntroductionCreate);
      var one = this.IntroductionRequestService.AddIntroductionRequest(ConnectionIntroductionCreate)
      one.subscribe(data => {
        this.openSnackBar("Introduction Request created", "close");

      });
      location.reload();
    }
  }

  changeTags(value: any) {
    this.tagsSelected = value;
  }

  animal: string | undefined;
  name: string | undefined;

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '250px',
      data: {name: this.name, animal: this.animal}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != undefined) {
        this.toppingList.push(result);
      }
    });

  }

}
