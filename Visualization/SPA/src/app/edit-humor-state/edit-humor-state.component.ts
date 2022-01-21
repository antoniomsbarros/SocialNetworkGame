import { Component, OnInit } from '@angular/core';
import {PlayersService} from "../services/players/players.service";
import {Location} from "@angular/common";
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {EmotionalStatus} from "../sign-in/sign-in.component";

@Component({
  selector: 'app-edit-humor-state',
  templateUrl: './edit-humor-state.component.html',
  styleUrls: ['./edit-humor-state.component.css']
})
export class EditHumorStateComponent implements OnInit {

  player = new FormGroup({
    emotionalStatus: new FormControl('', [Validators.required]),
  });

  player1: PlayersService[] = [];

  constructor(private playerService: PlayersService, private location: Location) {
  }

  ngOnInit(): void {
  }

  changeHumor() {
    let humor = this.emotionalStatus.value;
    console.log(humor);

    this.playerService.changeHumor('fds2@email.com', humor).subscribe(player => {
      this.player1.push(player);
    });
  }
  goBack(): void {
    this.location.back();
  }

  get emotionalStatus(): any {
    return this.player.get('emotionalStatus');
  }

  public rowEmotionalStatus(): Array<string> {
    const keys = Object.keys(EmotionalStatus);
    return keys.slice(keys.length / 2);
  }
}
