import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Location} from "@angular/common";
import {RelationshipsService} from "../services/relationships/relationships.service";
import {PlayersService} from "../services/players/players.service";
import {RelationshipDto} from "../DTO/relationships/RelationshipDto";
import {DialogComponent} from "../dialog-component/dialog.component";
import {MatDialog} from "@angular/material/dialog";
import {PlayerDto} from "../dto/players/PlayerDto";

@Component({
  selector: 'app-edit-relationship-tags-connection-force',
  templateUrl: './edit-relationship-tags-connection-force.component.html',
  styleUrls: ['./edit-relationship-tags-connection-force.component.css']
})
export class EditRelationshipTagsConnectionForceComponent implements OnInit {

  tags = new FormControl();
  tagsList: string[] = [];
  tagsSelected: string[] = [];
  connectionStrength: any;

  constructor(private location: Location,
              private relationshipService: RelationshipsService,
              private playerService: PlayersService,
              public dialog: MatDialog) {
  }

  data: RelationshipDto[] = []

  selectRelationship = new FormGroup({
    selectedRelationship: new FormControl('', [Validators.required]),
  });

  get relationship(): any {
    return this.selectRelationship.get("selectedRelationship");
  }

  ngOnInit(): void {
    this.refreshData();
  }

  refreshData() {
    this.relationshipService.getRelactionPLayer(this.playerService.getCurrentLoggedInUser()).subscribe(data => {
      this.data = data;
    })
  }

  selectedRelationship!: RelationshipDto

  formGroup = new FormGroup({
    newStrength: new FormControl('', [Validators.required]),
    tags:  new FormControl()
  });


  animal: string | undefined;
  name: string | undefined;

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '250px',
      data: {name: this.name, animal: this.animal}

    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != undefined) {
        this.selectedRelationship.tags.push(result)
        console.log(result, this.selectedRelationship)

      }
    });
  }

  changeTags(value: any) {
    this.tagsSelected = value;
  }


  goBack(): void {
    this.location.back();
  }

  getCurrentStrength(email: string) {
    let player = this.data.find(r => r.id == email)
    if (player)
      return player.connectionStrength
    return 0
  }

  setSelectedRelationship($event: Event, value: string) {
    let relationship = this.data.find(r => r.id == value)
    if (relationship)
      this.selectedRelationship = relationship
  }

  updateData(newStrength: any) {
    this.relationshipService.updateRelationship({
      id: this.selectedRelationship.id,
      connectionStrength: newStrength,
      tags: this.selectedRelationship.tags,
      playerOrig: this.selectedRelationship.playerOrig,
      playerDest: this.selectedRelationship.playerDest
    } as RelationshipDto).subscribe(updatedRelationship => {
      this.refreshData();
    });
  }
}
